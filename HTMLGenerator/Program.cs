

using HTMLGeneratorLibrary;

string result = "Hello World";

string HtmlPage = "<html>\r\n<head>\r\n<title>Шапка</title>\r\n</head>\r\n<body>\r\n{{result}}\r\n</body>\r\n</html>";

var gs = new GeneratorService();
var res = gs.GetHTML(HtmlPage, result);

var n = 0; 