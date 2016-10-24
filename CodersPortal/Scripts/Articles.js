
$('#newsStories').easyPaginate({
    paginateElement: 'div',
    elementsPerPage: 6,
    effect: 'slide'
});

function Article(newAuthor, newTitle, newArticle, newImageUrl, newOriginalUrl, newPublishDate) {
    this.author = newAuthor;
    this.title = newTitle;
    this.article = newArticle;
    this.imageUrl = newImageUrl;
    this.originalUrl = newOriginalUrl;
    this.publishDate = newPublishDate;
}


function NewsAPI() {
    var currentUrl = 'https://newsapi.org/v1/articles?source=techcrunch&apiKey=3b9f2c238e8c45858c0ee7fa375b95d3';
    var allArticles = [];
    $.ajax
       ({
           type: "GET",
           url: currentUrl,
           //dataType: "json",
           success: function (response) {
               var myArticles = response.articles;
               for (var item in myArticles) {
                   for (var i = 0; i < myArticles.length; i++) {
                       var x = myArticles[i];
                       allArticles.push(new Article(x.author, x.title, x.description, x.urlToImage, x.url, x.publishedAt));
                   }
               }
               SendToController(allArticles);
           }});
}

function SendToController(allArticles){
    $.ajax({
        type: "POST",
        url: "http://localhost:24380/NewsArticles/SaveArticles",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(allArticles)
    });
}

function loadComments(commentList) {
    var html = "";
    for (var item in commentList) {
        html += '<div id="label">';
        html += '<strong>' + item.Name + ':</strong><br> ' + item.UserComment;
        html += '<div>';
    }
    $('#commentSection').html(html);
}

function Comment(id, name, comment) {
    this.newsArticleId = id;
    this.name = name;
    this.usercomment = comment;
}

function SaveComment(ArticleId, userName, listOfComments) {
    var userComment = $('#comment').val();
    $('#comment').val() = "";
    var fullComment = new Comment(ArticleId, userName, userComment);
    $.ajax({
        type: "POST",
        url: "http://localhost:24380/NewsArticles/SaveComments",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(fullComment)
    });
    loadComments(listOfComments);
}

function GetText() {
    return $('#currentUserComment').val();
}


