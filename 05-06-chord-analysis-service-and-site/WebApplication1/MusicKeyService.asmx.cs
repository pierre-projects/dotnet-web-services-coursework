using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class MusicKeyService : WebService
    {
        // Map note names with sharps/flats to semitone offsets (C = 0)
        private static readonly Dictionary<string, int> NoteMap =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                { "C", 0 },
                { "C#", 1 }, { "Db", 1 },
                { "D", 2 },
                { "D#", 3 }, { "Eb", 3 },
                { "E", 4 },
                { "F", 5 },
                { "F#", 6 }, { "Gb", 6 },
                { "G", 7 },
                { "G#", 8 }, { "Ab", 8 },
                { "A", 9 },
                { "A#", 10 }, { "Bb", 10 },
                { "B", 11 }
            };

        public MusicKeyService()
        {
        }

        // Basic token-format validation: A–G with optional # or b, no B#
        private static bool IsValidNoteToken(string note)
        {
            if (string.IsNullOrWhiteSpace(note))
            {
                return false;
            }

            note = note.Trim();

            // Must be 1 or 2 characters: A–G, optional # or b
            if (note.Length < 1 || note.Length > 2)
            {
                return false;
            }

            char letter = char.ToUpperInvariant(note[0]);
            if (letter < 'A' || letter > 'G')
            {
                return false;
            }

            if (note.Length == 2)
            {
                char accidental = note[1];
                if (accidental != '#' && accidental != 'b')
                {
                    return false;
                }
            }

            // Explicitly forbid B# 
            if (string.Equals(note, "B#", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            return true;
        }

        [WebMethod(Description = "Analyzes a set of note names (e.g: 'C E G') and returns a chord quality description.")]
        public string AnalyzeChord(string notes)
        {
            if (string.IsNullOrWhiteSpace(notes))
            {
                return "Please enter at least one note name, for example: C E G or A C# E.";
            }

            string[] tokens = notes
                .Split(new[] { ' ', ',', ';', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            List<int> pitchClasses = new List<int>();
            List<string> invalidNotes = new List<string>();

            foreach (string raw in tokens)
            {
                string note = raw.Trim();

                // Enforce formatting rules first
                if (!IsValidNoteToken(note))
                {
                    invalidNotes.Add(note);
                    continue;
                }

                // Then map to pitch class
                if (NoteMap.TryGetValue(note, out int value))
                {
                    pitchClasses.Add(value);
                }
                else
                {
                    // Valid looking token but not in map 
                    invalidNotes.Add(note);
                }
            }

            if (invalidNotes.Count > 0)
            {
                return "Unrecognized or invalid note name(s): " + string.Join(", ", invalidNotes) +". Use notes like C, D#, Eb, F#, Bb, each separated by spaces.";
            }

            // Remove duplicates and sort
            pitchClasses = pitchClasses.Distinct().OrderBy(v => v).ToList();

            if (pitchClasses.Count == 0)
            {
                return "No valid notes were provided.";
            }

            if (pitchClasses.Count == 1)
            {
                return $"Only one note ({tokens[0].Trim()}) was provided. This is not enough to form a chord.";
            }

            // Use the first note from input as the root name
            // lowest pitch class as the numeric root for intervals.
            string rootName = tokens[0].Trim();
            int rootPc = pitchClasses[0];

            // Compute intervals from root (mod 12)
            List<int> intervals = pitchClasses
                .Select(pc => (pc - rootPc + 12) % 12)
                .Distinct()
                .OrderBy(i => i)
                .ToList();

            // Always ensure root is present
            if (!intervals.Contains(0))
            {
                intervals.Insert(0, 0);
            }

            string intervalPattern = string.Join(",", intervals);

            string quality = ClassifyChord(intervals);

            if (quality == "Unknown")
            {
                return $"Input: {notes}\n" +
                       $"Root: {rootName}\n" +
                       $"Intervals from root (in semitones): {intervalPattern}\n" +
                       "This pattern does not match a basic major, minor, diminished, augmented, or power chord.";
            }

            return $"Input: {notes}\n" +
                   $"Detected chord: {rootName} {quality}\n" +
                   $"Intervals from root (in semitones): {intervalPattern}";
        }

        private static string ClassifyChord(List<int> intervals)
        {
   

            var set = new HashSet<int>(intervals);

            // Power chord (two or three notes, but mainly root + fifth)
            if (set.SetEquals(new[] { 0, 7 }) && intervals.Count <= 3)
            {
                return "power chord (5th chord)";
            }

            if (set.SetEquals(new[] { 0, 4, 7 }))
            {
                return "major chord";
            }

            if (set.SetEquals(new[] { 0, 3, 7 }))
            {
                return "minor chord";
            }

            if (set.SetEquals(new[] { 0, 3, 6 }))
            {
                return "diminished chord";
            }

            if (set.SetEquals(new[] { 0, 4, 8 }))
            {
                return "augmented chord";
            }

            return "Unknown";
        }
    }
}
