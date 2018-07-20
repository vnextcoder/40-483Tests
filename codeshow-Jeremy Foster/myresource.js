var mod=(function(){	

var m=2000, c=0, d=10, y=2;
	return {
	getHiddenYear: function(){
	
		return m+c+d+y;
	}
	
	}
}());
function abc()
{
var x=mod.getHiddenYear();

alert(x);
}

function sayhello()
{
	alert("Hello ");
	//abc();
	Exceptiontester();
	
}


var counter = (function() {
  var privateCounter = 0;
  function changeBy(val) {
    privateCounter += val;
  }
  return {
    increment: function() {
      changeBy(1);
    },
    decrement: function() {
      changeBy(-1);
    },
    value: function() {
      return privateCounter;
    }
  };   
})();

//alert(counter.value()); /* Alerts 0 */
//counter.increment();
//counter.increment();
//alert(counter.value()); /* Alerts 2 */
//counter.decrement();
//alert(counter.value()); /* Alerts 1 */

function Exceptiontester()
{
try
{
	var i=10/0;
	adddlert("i is " + i) 
}
catch(ex)
{
	
	document.getElementById("Errormessage").innerHTML=	"Exception occurred is " + ex.message + "<br/>"+ ex.stack.replace(/\n/gi,"<br/>");
	//document.getElementById("Errormessage").innerHTML=	"Exception occurred is " + ex.message + "<br/>"+ replaceAll(ex.stack,"\n","<br/>");
	
	
}
finally
{
	alert("hello i am in finally");
		myFunction();
}
}
function myFunction() {
    //var str = document.getElementById("demo").innerHTML;

var str="abc\nxya\nbad\nasfkj\n\nhalua\ntrying\nto\nto\ndo";
 
    var res = str.replace(/\n/g, "<br/>");
    document.getElementById("demo").innerHTML = res;
}


function replaceAll(oldStr, removeStr, replaceStr, caseSenitivity){
    if(caseSenitivity == 1){
        cs = "g";
        }else{
        cs = "gi";  
    }
    var myPattern=new RegExp(removeStr,cs);
    newStr =oldStr.replace(myPattern,replaceStr);
    return newStr;
}

/*
function f()

{
	return [1,2000];
	
}
var a, b;
[a, b] = f();
alert("A is " + a + " B is " + b);*/
