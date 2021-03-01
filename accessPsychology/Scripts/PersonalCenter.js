//删除博客
function deleteBlog(id,index) {
    $.ajax({
        url: '/PersonalCenter/DeleteBlog',
        data: { id: id },
        dataType: 'text',
        success: function (res) {
            alert(res);
            $("[name=" + index + "]").remove();
        }
    })
}
//加载收藏夹内容
function loadFavContent() {

}

$(function () {
    $('.container').css('left', '0');
    var item = document.getElementsByClassName('nav-item1');
    var select_nav = $('.select_nav').text();
    var now;
    if (select_nav == "1") {
        now = item[0];
    } else if (select_nav == "2") {
        now = item[1];
    } else if (select_nav == "3") {
        now = item[2];
    } else if (select_nav == "4") {
        now = item[3];
    }
    var nowBlock = $("[name='personalData']");
    $(item).bind('click', function () {
        $(now).removeClass('nowNav');
        $(this).addClass('nowNav');
        now = this;
        $(nowBlock).css('display', 'none');
        if ($(this).attr('name') == "1") {
            $("[name='personalData']").css('display', 'block');
            nowBlock = $("[name='personalData']");
        } else if ($(this).attr('name') == "2") {
            $("[name='myFavorite']").css('display', 'block');
            nowBlock = $("[name='myFavorite']");
        } else if ($(this).attr('name') == "3") {
            $("[name='myBlogs']").css('display', 'block');
            nowBlock = $("[name='myBlogs']");
        } else {
            $("[name='myQuestion']").css('display', 'block');
            nowBlock = $("[name='myQuestion']");
        }
    })
    $(now).click();
    //获取用户信息
    $.ajax({
        url: "/PersonalCenter/GetUsers",
        dataType: "json",
        success: function (result) {
            $.each(result, function (idx, obj) {
                $('.head-img').attr('src', obj.head_img);
                $('.nickname').text(obj.user_name);
                $('.user-id').text(obj.user_name);
                $('.sex').text(obj.sex);
                $('.telphone').text(obj.tel_phone);
                $('.user-type').text(obj.user_type);
                $('.self-introduce').text(obj.introduce);
            })
        }
    });
    //获取收藏表信息
    $.ajax({
        url: "/PersonalCenter/GetCollects",
        dataType: "json",
        success: function (result) {
            $.each(result, function (idx, obj) {
                var html = "";
                html += '<div class="favorites">';
                html += '<span class="default-favorites"> ' + obj.col_name + '</span > ';
                html += '<div class="wrap-num"> <span class="content-num">' + obj.contentNum + '</span>条内容</div > <svg class="linxin-chevronright" viewBox="0 0 1024 1024"><path d="M624.064 511.765333L287.808 176.682667a53.482667 53.482667 0 0 1-0.192-75.562667c0.064-0.042667 0.128-0.128 0.192-0.149333a53.866667 53.866667 0 0 1 76.010667 0l372.352 371.072c10.538667 10.474667 16.277333 24.896 15.701333 39.744a53.290667 53.290667 0 0 1-15.701333 39.765333L363.818667 922.56a53.866667 53.866667 0 0 1-76.010667 0 53.482667 53.482667 0 0 1-0.192-75.562667l0.192-0.128 336.256-335.104z" fill=""></path></svg>'
                html += '</div > ';
                $('.title1').after(html);
            })
        }
    })
    //获取用户发表博文信息
    $.ajax({
        url: "/personalCenter/GetArticles",
        data: { users_id: $('.user_id').text() },
        dataType: "json",
        success: function (result) {
            var i = 5;
            $.each(result, function (idx, obj) {
                var html = '<div class="own-blog" name="'+i+'"><span class="blog-title">' + obj.title + '</span ><div class="blog-footer"><span class="createTime">' + obj.creat_time + '</span><span class="glyphicon glyphicon-eye-open"></span><span class="visitNum">' + obj.views_num + '</span><div class="wrapOperateBlog"><a class="deleteBlog" onclick="deleteBlog('+obj.id+','+i+')">删除</a></div></div></div>';
                $(".title2").after(html);
                i++;
            })
        }
    })
    //获取用户提问信息
    $.ajax({
        url: "/personalCenter/GetQuestions",
        data: { users_id: $('.user_id').text() },
        dataType: "json",
        success: function (result) {
            var html;
            $.each(result, function (idx, obj) {
                html = '<div class="own-question"><span class="question-title"> ' + obj.quesition_content + '</span ><div class="blog-footer"><span class="askTime">' + obj.creat_time + '</span > <img src="~/images/回答.png" /> <span class="answerNum">' + obj.askNum + '</span> <div class="wrapOperateAsk"><a class="deleteAsk">删除</a></div></div ></div > ';
                $(".title3").after(html);
            })
        }
    })
})