


var items = 3;
for (var i = 1; i <= items; i++)   
{
      var result = 1;
      for (var j = i; j >= 1; j--)   {
           result *= j;
      }
      alert("The factorial of " + i + " = " + result);
}