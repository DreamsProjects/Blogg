// Write your JavaScript code.

function läggUpp()
{
    var titel = document.getElementById("titel");
    if (titel === null || titel === "")
    {
        alert("Du måste ha en titel")
    }

    else {
        //Ska nå C# klasserna här som tar hand om sqlconnection och allting!
    }
}

function countChar(val)
{
    var len = val.value.length;
    if (len >= 2000) {
        val.value = val.value.substring(0, 2000);
    } else {
        $('#charNum').text(2000 - len);
    }
};

function countTitel(val)
{
    var len = val.value.length;
    if (len >= 2000) {
        val.value = val.value.substring(0, 50);
    } else {
        $('#charTit').text(50 - len);
    }
};