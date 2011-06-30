# Strider Services: Tagging, Categorization, Deep-linking, Social realtime search

Official C# Library for these services.

## Installation

### Adding references
``` c#
  using Strider.Client.TextMiner.Client;
  using Strider.Client.TextMiner.Utils;
```

## Usage

### Getting configuration

``` c#
	    // Get the AppSettings section.
            ApplicationConfig config = new ApplicationConfig();
```

### Using synonyms-service

``` c#
            // Display synonyms
	    Console.WriteLine(config.GetSynNetEndPoint());
            SynonymService ss = new SynonymService(config.GetSynNetEndPoint());
            displaySynonyms(ss, "account");
            displaySynonyms(ss, "abc123");
```
### Using word definition service

``` c#
            // Display word definitions
            Console.WriteLine(config.GetWordDefinitionEndPoint());
            WordDefinitionService wds = new WordDefinitionService(config.GetWordDefinitionEndPoint());
            displayDefinitions(wds, "account");
            displayDefinitions(wds, "abc123");
```
### Using synonyms-service

``` c#
            // Display synonyms
	    Console.WriteLine(config.GetSynNetEndPoint());
            SynonymService ss = new SynonymService(config.GetSynNetEndPoint());
            displaySynonyms(ss, "account");
            displaySynonyms(ss, "abc123");
```
### Using text-miner service. Automatic categorization and tagging

``` c#
            // Get TextMiner response
            TextMinerService API_KEY";
            displayResults(tms, apiKey, 243);
            displayResults(tms, apiKey, 9876542);

	    // Post a new article for data mining
	    tms = new TextMinerService(config.GetTextMinerEndPoint());

	    // Displaying the result
        private static void displaySubmittedarticleResponse(TextMinerService tms)
        {
            Console.WriteLine("Submit article");
            string text = "Hundreds of thousands of British teachers, air traffic controllers, customs officers and other public sector workers went on strike Thursday, causing potential chaos for schoolchildren and travellers.";
            TextMinerResponse dto =  tms.Post(
                "Bjørn Lomborg", 
                "The Best Investments", 
                new Uri("http://edition.cnn.com/2011/BUSINESS/06/30/uk.strike/index.html?hpt=hp_t2"),
                text, 
                "us", 
                "social_thought", 
                "", 
                "API_KEY");
            Console.WriteLine(dto);
        }
	
```
### Please provide you feedback:
partners@striderdi.com
@happystrider


#### Author: [Strider Digital Intelligence, Armenak][0]
#### Contributors: [V. Sky Slavin](http://twitter.com/nakedslavin)

[0]: http://twitter.com/happystrider