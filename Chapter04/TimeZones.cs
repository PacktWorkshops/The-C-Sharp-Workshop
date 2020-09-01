using System;
using System.Collections.Generic;
using System.Linq;

namespace Chapter04
{
    /// <summary>
    /// Appendix on Dictionaries
    /// </summary>
    public static class TimeZones
    {
        public static Dictionary<string, TimeZoneInfo> ById => 
            TimeZoneInfo.GetSystemTimeZones()
            .OrderBy(timeZone => timeZone.Id)
            .ToDictionary(tz => tz.Id);

        public static Dictionary<string, TimeZoneInfo> ByCode
        {
            get
            {                
                // generate some suggested codes for all time zones, knowing that some will be duplicates.
                // we create this as a list because we're going to be adding and removing items dynamically to get it right
                var abbreviations = TimeZoneInfo.GetSystemTimeZones().Select(timeZone => new
                {
                    Code = getCode(timeZone.Id),
                    Info = timeZone
                }).ToList();

                // find out what codes are used more than once.
                // We'll need to make those unique by adding a numeric suffix on each duplicate
                var dupGroups = abbreviations
                    .GroupBy(item => item.Code)
                    .Where(grp => grp.Count() > 1)
                    .ToArray();

                // remove the duplicates from our main list; we're going to re-add them with numeric suffixes to make them unique
                foreach (var dupGrp in dupGroups)
                {
                    abbreviations.RemoveAll(item => item.Code.Equals(dupGrp.Key));
                }

                // for each duplicate code, add a numeric suffix to make it unique in our final list
                var fixedDuplicates = dupGroups
                    .SelectMany(grp => grp.Select((item, index) => new
                    {
                        Code = $"{item.Code}.{index + 1}",
                        item.Info
                    })).ToArray();

                abbreviations.AddRange(fixedDuplicates);

                return abbreviations.OrderBy(item => item.Code).ToDictionary(item => item.Code, item => item.Info);
                               
                // convert a time zone Id into a "code" that is a little more convenient to write than the full name,
                // joining the initial lower-case letters of the Id                
                string getCode(string timeZoneId)
                {
                    var parts = timeZoneId
                        .Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(word =>
                        {
                            var result = new string(word.Where(c => char.IsLetter(c) || char.IsNumber(c)).ToArray());
                            return result.Substring(0, 1).ToLower();
                        }).ToArray();

                    return string.Join(string.Empty, parts);
                }
            }
        }
            
        public static TimeSpan GetOffsetDifference(string convertToTimeZone) =>
            ById[TimeZoneInfo.Local.Id].BaseUtcOffset - 
            ById[convertToTimeZone].BaseUtcOffset;

        public static TimeSpan GetOffsetDifferenceByCode(string convertToCode) =>
            ByCode[TimeZoneInfo.Local.Id].BaseUtcOffset -
            ByCode[convertToCode].BaseUtcOffset;

    }
}
