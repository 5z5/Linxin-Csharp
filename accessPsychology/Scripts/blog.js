$(function () {
    $.ajax({
        url: "/Home/GetArticles",
        dataType: "json",
        success: function (result) {
            var html;
            $.each(result, function (idx, obj) {
                html = '<li>';
                html += '<div class="card card-home">'
                html += '<div class="card-title card-title-home"><a href="/Artdetail/detail/' + obj.id + '" class="H4">' + obj.title + '</a></div>';
                html += '<div class="card-footer-home"><div class="card-footer-body"><span class="author">' + obj.users_id + '</span><span class="glyphicon glyphicon-thumbs-up"></span><span class="thumbNum">' + obj.like_num + '</span></div></div>';
                html += '</div ></li >';
                $(".grow").append(html);
            })
        }
    })
});