//add Event listener for send button
var sendButton = document.getElementById("sendMessage");
sendButton.addEventListener("click", Send);

//add Event Listener for addRecipiant button
var addRecipiantBtn = document.getElementById("addRecipiant");
addRecipiantBtn.addEventListener("click", AddRecipiant);

//add Event Listener for deleteRecipiant button
var deleteRecipiant = document.getElementById("deleteRecipiant");
deleteRecipiant.addEventListener("click", DeleteRecipiant);

//for add option to select element
var recipiantsSelect = document.getElementById("selectRecipiants");

//for add option to select recipianList
var selectRecipiantsList = document.getElementById("selectRecipiantsList");
selectRecipiantsList.addEventListener("change", GetList);

GetAllList();



function Send() {
        var message = new Array($("#subject").val(), $("#message").val());
        $.ajax({
        url: "/api/sender/send",
            type: "POST",
            data: JSON.stringify(message),
            contentType: "application/json;charset=utf-8",
            success: function (data) {
        alert(data);
    }
        });
}

function AddRecipiant() {
    var recipiantName = document.getElementById("recipiantName");
    var name = recipiantName.value;
    $.ajax({
        url: "/api/sender/addRecipiant",
        type: "POST",
        data: JSON.stringify(name),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiant = new Array();
            recipiantsSelect.innerHTML = "";
            recipiant = JSON.parse(data);
            for (var i = 0; i < recipiant.length; i++) {
                recipiantsSelect.add(new Option(recipiant[i].Address, recipiant[i].Address));
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
        url: "/api/sender/deleteRecipiant",
        type: "POST",
        data: JSON.stringify(selectRecipiant),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiant = new Array();
            recipiantsSelect.innerHTML = "";
            recipiant = JSON.parse(data);
            for (var i = 0; i < recipiant.length; i++) {
                recipiantsSelect.add(new Option(recipiant[i].Address, recipiant[i].Address));
            }
        }
    });

}

function GetAllList() {   
    $.ajax({
        url: "/api/sender/getalllist",
        type: "Get",        
        success: function (data) {
            var recipiantList = new Array();
            selectRecipiantsList.innerHTML = "";
            recipiantList = JSON.parse(data);
            for (var i = 0; i < recipiantList.length; i++) {
                selectRecipiantsList.add(new Option(recipiantList[i].Name, recipiantList[i].Id));
            }
        }
    });
}

function GetList() {
    var selectOption = selectRecipiantsList.options[selectRecipiantsList.selectedIndex];
    var recipiantlistId = selectOption.value;
    $.ajax({
        url: "/api/sender/getRecipiantList",
        type: "Post",
        data: JSON.stringify(recipiantlistId),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiant = new Array();            
            recipiant = JSON.parse(data);
            for (var i = 0; i < recipiant.length; i++) {
                recipiantsSelect.add(new Option(recipiant[i].Address, recipiant[i].Address));
            }
        }
    });
}