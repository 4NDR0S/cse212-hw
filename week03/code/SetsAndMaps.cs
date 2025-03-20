using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE

        HashSet<string> wordSet = new HashSet<string>(words);
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            if (wordSet.Contains(word))
            {
                //find the reverse of the word
                string reversed = new string(word.ToCharArray().Reverse().ToArray());

                //if the reverse word is in the wordd set and is not the same word, add the pair 
                if (wordSet.Contains(reversed) && word != reversed)
                {
                    result.Add($"{word} & {reversed}");
                    //delete both words so we dont process them again
                    wordSet.Remove(word);
                    wordSet.Remove(reversed);
                }
            }
        }
        //return as an array
        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            //get the degree (4th column, index 3)
            var degree = fields[3].Trim();

            //if the degree is in the dictionary already, increment the counter
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                //if the degree is not in the dictionary, it get value of 1
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE

        //remove spaces and convert words to lowercase
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        //if words do not have same length, they can not be anagrams
        if (word1.Length != word2.Length)
        {
            return false;
        }

        //create two dictionaries so we can count the occurrences of each letter in both words
        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        //count the letters in word number 1
        foreach (var c in word1)
        {
            if (dict1.ContainsKey(c))
            {
                dict1[c]++;
            }
            else
            {
                dict1[c] = 1;
            }
        }

        //count the letters in word number 2
        foreach (var c in word2)
        {
            if (dict2.ContainsKey(c))
            {
                dict2[c]++;
            }
            else
            {
                dict2[c] = 1;
            }
        }

        //compare both dictionaries
        foreach (var kvp in dict1)
        {
            //if any letter has a different number in the two dictionaries, they are no anagrams
            if (!dict2.ContainsKey(kvp.Key) || dict2[kvp.Key] != kvp.Value)
            {
                return false;
            }
        }

        //if it get until here, the words are anagram!!!
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.


        //create a list of earthquake description
        var earthquakeDescriptions = featureCollection.Features
            .Select(feature => $"{feature.Properties.Place} - Mag {feature.Properties.Mag}")
            .ToArray();

        return earthquakeDescriptions;
    }
}