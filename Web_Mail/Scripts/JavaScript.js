
var sendButton = document.getElementById("sendMessage");
sendButton.addEventListener("click", Send);


var addRecipiantBtn = document.getElementById("addRecipiant");
addRecipiantBtn.addEventListener("click", AddRecipiant);


var deleteRecipiant = document.getElementById("deleteRecipiant");
deleteRecipiant.addEventListener("click", DeleteRecipiant);

var editButton = document.getElementById("editButton");
editButton.addEventListener("click", OpenEditWindow);


var recipiantsSelect = document.getElementById("selectRecipiants");


var selectRecipiantsList = document.getElementById("selectRecipiantsList");
selectRecipiantsList.addEventListener("change", GetList);

var addListbutton = document.getElementById("addList");
addListbutton.addEventListener("click", AddList);

var deleteRecipiantList = document.getElementById("deleteRecipiantList");
deleteRecipiantList.addEventListener("click", DeleteList);



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

function DeleteList() {
    var index = selectRecipiantsList.selectedIndex;
    var selectRecipiantList = selectRecipiantsList.options[index].value;
    selectRecipiantsList.remove(index);
    $.ajax({
        url: "/api/sender/deleteRecipiantList",
        type: "POST",
        data: JSON.stringify(selectRecipiantList),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            recipiantsSelect.innerHTML = "";
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
            recipiantsSelect.innerHTML = "";
            recipiant = JSON.parse(data);
            for (var i = 0; i < recipiant.length; i++) {
                recipiantsSelect.add(new Option(recipiant[i].Address, recipiant[i].Address));
            }
        }
    });
}

function AddList() {
    var listName = document.getElementById("listName").value;
    $.ajax({
        url: "/api/sender/addList",
        type: "POST",
        data: JSON.stringify(listName),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiantList = new Array();
            selectRecipiantsList.innerHTML = "";
            recipiantList = JSON.parse(data);
            for (var i = 0; i < recipiantList.length; i++) {
                selectRecipiantsList.add(new Option(recipiantList[i].Name, recipiantList[i].Id));
            }
            document.getElementById("listName").value = "";
        }
    });
}

function OpenEditWindow() {

    location.href = "Home/EditList/?id=2&name=myName";
}