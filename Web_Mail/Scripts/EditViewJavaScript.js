//add Event Listener for addRecipiant button
var addRecipiantBtn = document.getElementById("addRecipiant");
addRecipiantBtn.addEventListener("click", AddRecipiant);

//add Event Listener for deleteRecipiant button
var deleteRecipiant = document.getElementById("deleteRecipiant");
deleteRecipiant.addEventListener("click", DeleteRecipiant);

//for add option to select element
var recipiantsSelect = document.getElementById("selectRecipiants");

var listId = document.getElementById("listName");

var recipiantName = document.getElementById("recipiantName");
recipiantName.addEventListener("change", NormalBorder);

var okButton = document.getElementById("okButton");
okButton.addEventListener("click", OpenMainWindow);



GetList();



function validateEmail(emailField) {
    var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

    if (reg.test(emailField.value) == false) {
        return false;
    }

    return true;

}

function NormalBorder(event) {
    event.target.style.borderColor = "black";    
}

function AddRecipiant() {     
    var name = recipiantName.value;
    var id = listId.attributes.value.nodeValue;
    if (validateEmail(name)) {    
    var newRecipiant = { Id: id, Name: name };
    $.ajax({
        url: "/api/sender/addRecipiantForList",
        type: "POST",
        data: JSON.stringify(newRecipiant),
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
    else {
        recipiantName.style.borderColor = "red";
        recipiantName.value = "";
    }
}

function DeleteRecipiant() {
    var index = recipiantsSelect.selectedIndex;
    var selectRecipiant = recipiantsSelect.options[index].value;
    var id = listId.attributes.value.nodeValue;
    var deleteRecipiant = { Id: selectRecipiant, IdList: id };
    recipiantsSelect.remove(index);
    $.ajax({
        url: "/api/sender/deleteRecipiantFromList",
        type: "POST",
        data: JSON.stringify(deleteRecipiant),
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

function GetList() {
    var id = listId.attributes.value.nodeValue;
    $.ajax({
        url: "/api/sender/getRecipiantListforEdit",
        type: "Post",
        data: JSON.stringify(id),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiantList = new Array();
            recipiantsSelect.innerHTML = "";
            recipiantList = JSON.parse(data);
            for (var i = 0; i < recipiantList.length; i++) {
                recipiantsSelect.add(new Option(recipiantList[i].Mail, recipiantList[i].Id));
            }
        }
    });
}

function OpenMainWindow() {

    location.href = "../../Home/Index";
}