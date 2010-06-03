(function ($) {
    $.fn.pager = function (p, handler) {
        var page = $(this);
        if (page.length == 0) return;
        p.pages = Math.ceil(p.total / p.rp);
        page.html(p.page + "/" + p.pages);
        var breakspan = '<span class="break">...</span>';
        var getPage = function (pg, t) {
            return $("<a></a>").attr('href', 'javascript:void(0)').click(function () {
                handler(pg);
            }).text(t);
        };
        if (p.page > 1) {
            if (p.page - 2 > 1) {
                page.append(getPage(1, '< <')).append(breakspan);
            }
            page.append(getPage(p.page - 1, "< \u4e0a\u4e00\u9875"));
        }
        for (var i = 2; i <= 6; i++) {
            if ((p.page + i - 4) >= 1 && (p.page + i - 4) <= p.pages) {
                if (4 == i) {
                    page.append($('<span class="this-page"></span>').text(p.page));
                } else {
                    page.append(getPage(p.page + i - 4, p.page + i - 4));
                }
            }
        }
        if (p.page < p.pages) {
            page.append(getPage(1 + p.page, "\u4e0b\u4e00\u9875 >"));
            if (p.page + 2 < p.pages) {
                page.append(breakspan).append(getPage(p.pages, "> >"));
            }
        }
    };
})(jQuery);
/*
$('.page').pager({page:1,total:1000,rp:10},function(r){
 //load
});

.page{position:relative; clear:both; margin:10px 0; text-align:center; line-height:24px;font-size:12px;}
.page:after{content:"."; display:block; height:0; clear:both; visibility:hidden;}
* html .page{height:1%;}
*+html .page{min-height:1%;}
.page .this-page{margin:0 5px;padding:2px 6px; border:solid 1px #ff8844; background:#fff; color:#ff8844;font-weight:bold;}
.page a{margin:0 5px;padding:2px 6px; border:solid 1px #d8dfea; background:#fff; color:#3B5999; text-decoration:none;}
.page a:hover{border:solid 1px #d8dfea; color:#fff; background:#3B5999; text-decoration:none;}
.page .pageCount{display:block; color:#808080; text-align:center;}
.page select{float:left;}
*/