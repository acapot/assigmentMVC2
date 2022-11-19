function ajaxPeopleList(actionUrl) {
    $.get(actionUrl, function (response) {
        document.getElementById("result").innerHTML = response;
    });
}

function ajaxPost(actionUrl, inputId) {
    let inputElement = $("#" + inputId);
    var data = {
        [inputElement.attr("name")]: inputElement.val()

    }
    $.post(actionUrl, data, function (response) {
        document.getElementById("result").innerHTML = response;
    })
}