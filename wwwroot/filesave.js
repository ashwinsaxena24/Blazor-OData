function saveFile(csv, fileName) {
    var fileType = 'text/csv;charset=utf-8';
    if (navigator.msSaveBlob) { // IE 
        navigator.msSaveBlob(new Blob([csv], {
            type: fileType
        }), fileName + '.csv');
    }
    else {
        var e = document.createElement('a');
        e.setAttribute('href', 'data:' + fileType + ',' + encodeURIComponent(csv));
        e.setAttribute('download', fileName + '.csv');
        e.style.display = 'none';
        document.body.appendChild(e);
        e.click();
        document.body.removeChild(e);
    }
}