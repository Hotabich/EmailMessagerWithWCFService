//add Event Listener for addRecipiant button
var addRecipiantBtn = document.getElementById("addRecipiant");
addRecipiantBtn.addEventListener("click", AddRecipiant);

//add Event Listener for deleteRecipiant button
var deleteRecipiant = document.getElementById("deleteRecipiant");
deleteRecipiant.addEventListener("click", DeleteRecipiant);

//for add option to select element
var recipiantsSelect = document.getElementById("selectRecipiants");

var listId = document.getElementById("listId");






function AddRecipiant() {
    var recipiantName = document.getElementById("recipiantName");
    var name = recipiantName.value;
    var id = listId.attributes.value.nodeValue;
    $.ajax({
        url: "/api/sender/addRecipiantForList",
        type: "POST",
        data: JSON.stringify({ id, name }),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiant = new Array();
            recipiantsSelect.innerHTML = "";
            recipiant = JSON.parse(data);
            for (var i = 0; i < recipiant.length; i++) {
                recipiantsSelect.add(new Option(recipiant[i].Mail, recipiant[i].Id));
            }
            recipiantName.value = "";
        }
    });
}

function DeleteRecipiant() {
    var index = recipiantsSelect.selectedIndex;
    var selectRecipiant = recipiantsSelect.options[index].value;
    recipiantsSelect.remove(index);
    $.ajax({
        url: "/api/sender/deleteRecipiantFromList",
        type: "POST",
        data: JSON.stringify(selectRecipiant),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiant = new Array(); 
            recipiantsSelect.innerHTML = "";
            recipiant = JSON.parse(data);
            for (var i = 0; i < recipiant.length; i++) {
                recipiantsSelect.add(new Option(recipiant[i].Mail, recipiant[i].Id));
            }
        }
    });
}