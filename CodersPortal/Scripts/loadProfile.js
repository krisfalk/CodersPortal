


function loadProfile(toPage) {
    alert(toPage);
    $('#profileInsert').html(toPage);
}

function Profile(html, id) {
    this.currentHTML = html;
    this.currentProfileId = id;
}

function SaveHTML(id) {
    //var test = document.getElementById("editable").innerHTML.toString();
    var editedHTML = $('#editable').val($('#editable').html());
    editedHTML = $(editedHTML).text();
    var profile = new Profile(editedHTML, id);
    $.ajax({
        type: "POST",
        url: "http://localhost:24380/Profiles/SaveHTML",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(profile)
    });
}