//add Event listener for send button
var sendButton = document.getElementById("sendMessage");
sendButton.addEventListener("click", Send);

//add Event Listener for addRecipiant button
var addRecipiantBtn = document.getElementById("addRecipiant");
addRecipiantBtn.addEventListener("click", AddRecipiant);

//for add option to select element
var recipiantsSelect = document.getElementById("selectRecipiants");


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
    var recipiantName = $("#recipiantName").val();
    $.ajax({
        url: "/api/sender/addRecipiant",
        type: "POST",
        data: JSON.stringify(recipiantName),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recipiant = new Array();
            recipiantsSelect.innerHTML = "";
            recipiant = JSON.parse(data);
            for (var i = 0; i < recipiant.length; i++) {
                recipiantsSelect.add(new Option(recipiant[i], recipiant[i]));
            }
        }
    });
}