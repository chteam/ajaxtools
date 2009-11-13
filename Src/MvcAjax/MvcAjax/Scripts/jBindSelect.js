/// <reference path="jquery-1.3.1-vsdoc.js" />
//written by Jian Zou
//http://www.cnblogs.com/chsword
//project http://ajax.codeplex.com
var createArray = function(b, e) {
    var a = new Array();
    for (var i = b; i <= e; i++)
        a.push(i);
    return a;
};
$.fn.bindselect = function(op) {
    if (null == op) return;
    var s = this.get(0);
    var o = op["source"];
    var t = op["text"];
    var v = op["value"];
    var sl = op["selectvalue"];
    s.options.length = 0;
    for (var i = 0; i < o.length; ++i) {
        if (t == null && v == null)
            s.options.add(new Option(o[i], o[i]));
        else
            s.options.add(new Option(o[i][t], o[i][v]));
    }
    if (sl != null) this.val(sl);
    return this;
};
$.fn.dateselect = function(op) {
    if (op == null) op = {};
    var gl = function(v) {
        var d = new Date(v);
        if (isNaN(d.getDate())) d = new Date();
        return { year: d.getFullYear(), month: d.getMonth() + 1, day: d.getDate() };
    };
    var getDef = function(key, defv) {
        if (op[key] == null) return defv;
        else return op[key];
    };
    var v = gl(this.val());
    var id = this.attr("id");
    var y = $('#' + id + '_year');
    var m = $('#' + id + '_month');
    var d = $('#' + id + '_day');
    var h = this;
    var change = function() { h.val(y.val() + '-' + m.val() + '-' + d.val()); };
    y.bindselect({ source: createArray(getDef('begin', 1949), getDef('end', 2020)), selectvalue: v.year }).change(change);
    m.bindselect({ source: createArray(1, 12), selectvalue: v.month }).change(change);
    d.bindselect({ source: createArray(1, 31), selectvalue: v.day }).change(change);
};