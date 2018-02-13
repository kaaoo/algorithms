$(function () {
    var c = document.body;

    console.log(allDescendants(c, 0));
});

function allDescendants(node, count) {
    var innernodes = node.childNodes
    for (var i = 0; i < node.childNodes.length; i++) {
        var child = node.childNodes[i];
        if (child.nodeName === 'OL' || child.nodeName === 'UL') {
            console.log(child.nodeName);
            count++;
        }
        count = allDescendants(child, count);
    }
    return count;
}