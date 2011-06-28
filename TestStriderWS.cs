using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;

using Strider.Client.TextMiner.Client;
using Strider.Client.TextMiner.Utils;

namespace StriderWS
{
    class TestStriderWS
    {

        static void Main(string[] args)
        {

            // Get the AppSettings section.
            ApplicationConfig config = new ApplicationConfig();

            // Display synonyms
            Console.WriteLine(config.GetSynNetEndPoint());
            SynonymService ss = new SynonymService(config.GetSynNetEndPoint());
            displaySynonyms(ss, "account");
            displaySynonyms(ss, "abc123");

            // Display word definitions
            Console.WriteLine(config.GetWordDefinitionEndPoint());
            WordDefinitionService wds = new WordDefinitionService(config.GetWordDefinitionEndPoint());
            displayDefinitions(wds, "account");
            displayDefinitions(wds, "abc123");

            // Get TextMiner response
            TextMinerService tms = new TextMinerService(config.GetTextMinerEndPoint());
            string apiKey = "API_KEY";
            displayResults(tms, apiKey, 243);
            displayResults(tms, apiKey, 9876542);

            // Post a new article
            tms = new TextMinerService(config.GetTextMinerEndPoint());
            displaySubmittedarticleResponse(tms);

            // Request for a new client API key
			// or drop us a line at partners@striderdi.com or @happystrider
            ClientService cs = new ClientService(config.GetClientServiceEndPoint());
            displayApiKey(cs, "Strider Digital Intelligence", "partners@striderdi.com", "Strider Digital Intelligence");            
            
        }

        static void displaySynonyms(SynonymService ss, string word)
        {

            Console.WriteLine("Display synonyms");
            Synonyms dto = ss.GetSynonyms(word);
            if (dto.synonyms == null)
            {
                Console.WriteLine("No synonym is available");
            }
            else
            {
                Console.WriteLine(dto);
            }
              
        }

        
        static void displayDefinitions(WordDefinitionService wds, string word)
        {
            Console.WriteLine("Display word definitions");
            WordDefinitions dto = wds.GetWordDefinitions(word);
            if (dto.definitions == null)
            {
                Console.WriteLine("No definition is available");
            }
            else
            {
                Console.WriteLine(dto);
            }
        }
        
        private static void displayResults(TextMinerService tms, string apiKey, int articleId)
        {
            Console.WriteLine("Display categories and tags");
            TextMinerResponse dto = tms.Get(apiKey, articleId);
            Console.WriteLine(dto);
        }

        private static void displayApiKey(ClientService cs, string organization, string email, string name)
        {

            Console.WriteLine("Apply for API key");
            Client dto = cs.RequestApiKey(organization, email, name);
            Console.WriteLine(dto);
        }

        private static void displaySubmittedarticleResponse(TextMinerService tms)
        {
            Console.WriteLine("Submit article");
            string text = "Zwei Jahre sind vergangen, seit die Finanzkrise ausbrach, und erst jetzt wird uns langsam klar, wie teuer sie wahrscheinlich werden wird. Andrew Haldane von der Bank of England schätzt, dass der gegenwärtige Wert der entsprechenden zukünftigen Produktionsverluste gut 100 % des Welt-BIP erreichen könnte. Diese Schätzung mag erstaunlich hoch aussehen, doch ist sie relativ vorsichtig, da sie davon ausgeht, dass nur ein Viertel des ursprünglichen Schocks zu einer dauerhaft niedrigeren Produktion führen wird. Hört man auf die wahren Weltuntergangspropheten, die glauben, dass ein Großteil, wenn nicht sogar der gesamte Schock dauerhafte Auswirkungen auf die Produktion haben wird, könnte der Gesamtverlust zwei- oder dreimal so hoch ausfallen. Das Welt-BIP eines Jahres beläuft sich auf 60 Billionen US-Dollar, das entspricht etwa fünf Jahrhunderten offizieller Entwicklungshilfe oder, um noch konkreter zu werden, 10 Milliarden Klassenzimmern in afrikanischen Dörfern. Natürlich sind dies keine direkten Kosten für die öffentlichen Haushalte (die Gesamtkosten der Bankenrettungspakete sind wesentlich geringer), doch kommt es vor allem auf die Kosten der verlorenen Produktion an, wenn man über eine Verringerung der Krisenhäufigkeit nachdenkt. Angenommen, ohne adäquate vorbeugende Maßnahmen kommt es alle 50 Jahre zu einer Krise, die ein Jahr des Welt-BIP kostet (eine ungefähre, jedoch nicht übermäßige Annahme). In diesem Falle wäre eine Versicherung für die Bürger der Welt sinnvoll, solange der Versicherungsbeitrag unter 2 % des BIP bleibt (100 %:50). Eine einfache Methode zur Verringerung der Häufigkeit von Krisen ist, von Banken zu verlangen, sich stärker auf Eigenkapital und weniger auf Schulden zu verlassen, sodass sie höhere Verluste hinnehmen können, ohne insolvent zu werden – eine Maßnahme, die zurzeit auf globaler Ebene in Betracht gezogen wird. Aus Berichten, die das Forum für Finanzstabilität (Financial Stability Board) und der Baseler Ausschuss unlängst veröffentlichten – einer über die langfristigen Folgen der höheren Eigenkapitalanforderungen und der andere über die vorübergehenden Effekte ihrer Einführung –, wissen wir nun mehr über die wahrscheinlichen Auswirkungen solcher Regelungen. Der erste Bericht stellt fest, dass eine Erhöhung der Eigenkapitalquote um 1 % – ausgehend vom aktuellen niedrigen Niveau der Kapitalausstattung der Banken – die Häufigkeit von Krisen um ein Drittel verringern würde, während die Zinssätze dadurch um etwa 13 Basispunkte steigen würden (die Banken müssten höhere Gebühren verlangen, weil es sie mehr kostet, Kapital aufzunehmen als Schuldentitel zu emittieren). Mit anderen Worten: Der Preis dafür, die Einkünfte eines Jahres alle 75 Jahre anstatt alle 50 Jahre zu verlieren, würde dazu führen, dass die Banken die Zinsen für einen Kredit von 4 % auf 4,13 % erhöhen. Eine so unbedeutende Erhöhung würde höchstens dazu führen, dass einige Bankkunden sich alternative Finanzierungsquellen suchen, höchstwahrscheinlich ohne erkennbaren Effekt auf das BIP. Es überrascht, dass eine Vorschrift so viel Positives zu einem so geringen Preis bewirken kann – die Kosten sind wesentlich geringer als in vielen anderen Bereichen, in denen die Politik ökonomisch kostspielige Sicherheitsanforderungen verlangt. Man denke beispielsweise an den Umweltschutz oder das Gesundheitswesen, wo Entscheidungen vom Vorsorgeprinzip geleitet werden. So viel zu den langfristigen Aussichten. Die heiß diskutierte Frage heute lautet, ob der Übergang zu höheren Mindestreserven zu übermäßigen kurzfristigen Kosten führen würde (da die Banken wahrscheinlich die Darlehenszinsen erhöhen und die Kreditvolumen senken werden). Wenn die Banken, von denen einige noch notleidend sind, neuen Regelungen unterworfen werden, könnte dies dazu führen, die Kreditvergabe noch mehr zu senken und dadurch das Tempo des Wirtschaftsaufschwungs weiter zu verlangsamen. Was die Geschwindigkeit und Bestimmung des richtigen Zeitpunkts für eine Straffung der Vorschriften angeht, ist gutes Urteilsvermögen vonnöten. Der zweite Bericht stellt fest, dass die Erhöhung der Eigenkapitalquote der Banken um einen Prozentpunkt, sofern sie allmählich über vier Jahre eingeführt wird, das BIP um etwa 0,2 % verringern würde. Angesichts der Tatsache, dass häufig von einer Erhöhung um drei Prozentpunkte die Rede ist, könnte der Gesamteffekt 0,6 % betragen. Doch gibt es jede Menge Unsicherheiten. Merkwürdigerweise stellt der Bericht fest, dass die Erhöhung der Zieleigenkapitalquote einen größeren negativen Effekt in den Vereinigten Staaten hätte als im Euroraum, obwohl Letzterer stärker von der Finanzierung durch Banken abhängig ist. Darüber hinaus geht der Bericht davon aus, dass Geldpolitik einen Teil des Schocks abfedern kann, was bei den bereits vorherrschenden Zinssätzen von nahezu null Prozent nicht unbedingt stimmen muss – ebenso wenig im Euroraum, wo die Bemühungen der einzelnen Länder voneinander abweichen können, während die Geldpolitik für alle gleich ist. Daher könnte der Effekt neuer Regelungen auf Länder, in denen die Banken erheblich unterkapitalisiert sind, leicht vier- oder fünfmal so hoch ausfallen wie die Headline-Zahl und bei einem Vier-Jahres-Horizont ungefähr einen Prozentpunkt erreichen. Das mag immer noch gering aussehen, ist jedoch angesichts der kurzfristigen Wachstumsaussichten in den Industrieländern kein unbedeutender Betrag. In Zeiten, in denen das Wachstum zu schwach ist, um die massive Arbeitslosigkeit zu verringern, zählt jede Dezimalstelle. Wenn das Wachstum in dieser Größenordnung abgeschwächt wird, solange der Privatsektor seinen Schuldenabbauzyklus noch nicht vollständig beendet hat – und die Regierungen ihren eigenen beginnen –, riskiert man damit eine längere Beinahestagnation, die die kriseninduzierte Arbeitslosigkeit in strukturelle Arbeitslosigkeit verwandeln könnte. Ferner werden die strafferen Kreditstandards über einen längeren Zeitraum wahrscheinlich zu einer übermäßigen Beeinträchtigung schnell wachsender Unternehmen mit wenig Bargeld führen, was Folgen für Innovation, Produktivität und schließlich für das Wachstumspotenzial hat. Das soll nicht heißen, dass man den Banken die Regulierung ersparen und ihnen erlauben sollte, die erforderliche Kapitalaufstockung zu vergessen. Doch weisen die oben genannten Punkte darauf hin, dass – erstens – der richtige Zeitpunkt wichtig ist. Politische Entscheidungsträger sollten sich davor hüten, einen Regulierungsschock gleichzeitig zu einem Haushaltschock zu erzeugen. Aus diesem Grund ist es strategisch klug, jetzt neue Regulierungsstandards zu erlassen und gleichzeitig spätere Umsetzungsfristen festzulegen. Zweitens, aufgrund der Existenz und Höhe von Übergangskosten ist nicht alles, was die Wahrscheinlichkeit von Finanzkrisen verringert, auch wert, umgesetzt zu werden. Für Politiker, die auf aktuelle Schwierigkeiten fixiert sind, mag es zweitrangig erscheinen, ob die nächste Krise in 50 oder 75 Jahren auftritt. Daher muss eine gesetzgeberische Reform so gestaltet werden, dass sie die kurzfristigen Kosten so gering wie möglich hält. Höhere Eigenkapitalquoten und Liquiditätsgrade sind nur einer von mehreren Ansätzen, um das Finanzsystem sicherer zu gestalten. Andere Maßnahmen – beispielsweise eine Kapitalversicherung oder die Reform der Grenzen innerhalb der Finanzbranche à la Paul Volcker – sind es wert, berücksichtigt zu werden. Es besteht kein Zweifel daran, dass sich die langfristige Absicherung gegen Krisen lohnt. Das bedeutet jedoch nicht, dass eine Reform nicht so kosteneffektiv wie möglich sein sollte.";
            TextMinerResponse dto =  tms.Post(
                "Bjørn Lomborg", 
                "The Best Investments", 
                new Uri("http://www.project-syndicate.org/commentary/lomborg68/English"),
                text, 
                "us", 
                "social_thought", 
                "", 
                "API_KEY");
            Console.WriteLine(dto);
        }

    }
}
