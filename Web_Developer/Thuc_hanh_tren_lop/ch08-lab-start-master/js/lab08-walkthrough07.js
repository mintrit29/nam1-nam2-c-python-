var	daysOfWeek	=	new	Array("Mon","Tues","Wed", "Thur",	"Fri");
daysOfWeek.push("Sat");
daysOfWeek.unshift("Sun");
document.write(daysOfWeek+"<br/>");
document.write("<table	border=1>");
document.write("<tr>");
for	(i	=	0;	i	<	daysOfWeek.length;	i++)	{
    if	(daysOfWeek[i].length	<	4)
                    day	=	daysOfWeek[i];
    else
                    day	=	"<em>"	+	daysOfWeek[i]	+	"</em>";
    document.write("<th>"	+	day +	"</th>");
}
document.write("</tr>");
document.write("</table>");
var dateofweek1 = new Array("1","2","3","4","5","6","7");
var dateofweek2 = new Array("8","9","10","11","12","13","14");
var dateofweek3 = new Array("15","16","17","18","19","20","21");
var dateofweek4 = new Array("22","23","24","25","26","27","28");
var dateofweek5 = new Array("29","30");

document.write("<table	border=1>");
document.write("<tr>");
for	(var	i	=	0;	i	<	dateofweek1.length;	i++){
				document.write("<th>"	+	dateofweek1[i]	+	"</th>");
}
document.write("</tr>");
document.write("</table>");
document.write("<table	border=1>");
document.write("<tr>");
for	(var	i	=	0;	i	<	dateofweek2.length;	i++){
				document.write("<th>"	+	dateofweek2[i]	+	"</th>");
}
document.write("</tr>");
document.write("</table>");
document.write("<table	border=1>");
document.write("<tr>");
for	(var	i	=	0;	i	<	dateofweek3.length;	i++){
				document.write("<th>"	+	dateofweek3[i]	+	"</th>");
}
document.write("</tr>");
document.write("</table>");
document.write("<table	border=1>");
document.write("<tr>");
for	(var	i	=	0;	i	<	dateofweek4.length;	i++){
				document.write("<th>"	+	dateofweek4[i]	+	"</th>");
}
document.write("</tr>");
document.write("</table>");
document.write("<table	border=1>");
document.write("<tr>");
for	(var	i	=	0;	i	<	dateofweek5.length;	i++){
				document.write("<th>"	+	dateofweek5[i]	+	"</th>");
}
document.write("</tr>");
document.write("</table>");