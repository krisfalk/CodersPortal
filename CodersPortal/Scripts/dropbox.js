function uploadFile() {
    var ACCESS_TOKEN = 'xL8hmmM377AAAAAAAAAAEgevoM7uu1Zm0qmLSwK58fQ-VriYzy9aIWwfewpiau7z';
    var dbx = new Dropbox({ accessToken: ACCESS_TOKEN });
    var fileInput = document.getElementById('file-upload');
    var file = fileInput.files[0];
    dbx.filesUpload({ path: '/' + file.name, contents: file })
      .then(function (response) {
          var results = document.getElementById('results');
          results.appendChild(document.createTextNode('File uploaded!'));
          console.log(response);
      })
      .catch(function (error) {
          console.error(error);
      });
    return false;
}

function downloadFile() {
    var ACCESS_TOKEN = 'xL8hmmM377AAAAAAAAAAEgevoM7uu1Zm0qmLSwK58fQ-VriYzy9aIWwfewpiau7z';
    var SHARED_LINK = document.getElementById('shared-link').value;
    var dbx = new Dropbox({ accessToken: ACCESS_TOKEN });
    dbx.sharingGetSharedLinkFile({ url: SHARED_LINK })
      .then(function (data) {
          var downloadUrl = URL.createObjectURL(data.fileBlob);
          var downloadButton = document.createElement('a');
          downloadButton.setAttribute('href', downloadUrl);
          downloadButton.setAttribute('download', data.name);
          downloadButton.setAttribute('class', 'button');
          downloadButton.innerText = 'Download: ' + data.name;
          document.getElementById('results').appendChild(downloadButton);
      })
      .catch(function (error) {
          console.error(error);
      });
    return false;
}


//// ... file selected from a file <input>
//file = event.target.files[0];
//$.ajax({
//    url: 'https://content.dropboxapi.com/2/files/upload',
//    type: 'post',
//    data: file,
//    processData: false,
//    contentType: 'application/octet-stream',
//    headers: {
//        "Authorization": "Bearer " + ACCESS_TOKEN,
//        "Dropbox-API-Arg": '{"path": "/test_ff_upload.txt","mode": "add","autorename": true,"mute": false}'
//    },
//    success: function (data) {
//        console.log(data);
//    }
//})