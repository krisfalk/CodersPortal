
function loadProfile(toPage) {
    alert(toPage);
    $('#profileInsert').html(toPage);
}

function Profile(html, id, lvl) {
    this.currentHTML = html;
    this.currentProfileId = id;
    this.accessLevel = lvl;
}

function SaveHTML(id, accessLvl) {
    var editedHTML = $('#editable').val($('#editable').html());
    editedHTML = $(editedHTML).text();
    var profile = new Profile(editedHTML, id, accessLvl);
    $.ajax({
        type: "POST",
        url: "http://localhost:24380/Profiles/SaveHTML",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(profile)
    });
}

function LoadHTML(id) {
    var profile = new Profile("", id, "");
    $.ajax({
        type: "POST",
        url: "http://localhost:24380/Profiles/Details",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(id)
    });
}