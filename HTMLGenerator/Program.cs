using HTMLGenerator.Models;
using HTMLGeneratorLibrary;

string result = "Hello World";
var user = new User(343, "loginnew", "passwordnew", 18, "8987858594", "boku no pico");

string HtmlPage = "<html>\r\n<head>\r\n<title>Шапка</title>\r\n</head>\r\n<body>\r\n{{variable.Id}}\r\n<p>Логин и пароль пользователя: <p>\r\n{{variable.Login}}\r\n{{variable.Password}}\r\n</body>\r\n</html>";

var gs = new GeneratorService();
var res = gs.GetHTML(HtmlPage, user);

var n = 0; 