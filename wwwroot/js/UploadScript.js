var images
//var windowimage = document.getElementById('imgWindow');
var FileInput = document.getElementById('FileUrl');
//var AddUpload = document.getElementById('AddUpload');

//function SeeImages(input) {
//    if (input.files && input.files[0]) {
//        var reader = new FileReader();

//        reader.onload = function (e) {
//            $('#imgWindow').attr('src', e.target.result);
//            images = e.target.result;
//        }

//        reader.readAsDataURL(input.files[0])
//    }
//};

//$('#FileUrl').change(function () {
//    SeeImages(this);
//})

$('#AddUpload').click(function () {
    //alert(images);
    //var obj = {}

    //var img = images.split(",")
    //obj.FileUrl = img[1];

    //$.ajax({
    //    url: '@Url.Action("PostUpload", "Upload")',
    //    type: 'POST',
    //    dataType: 'JSON',
    //    data: { objs: obj },
    //    success: function (data) {

    //    }
    //})

    var files = FileInput.files;
    if (files.length > 0) {
        // Access the first selected file
        var selectedFile = files[0];

        // Access various properties of the file
        var fileName = selectedFile.name;
        var fileSize = selectedFile.size;
        var fileType = selectedFile.type;

        // You can use these values as needed
        alert("File Name: " + fileName + "\nFile Size: " + fileSize + " bytes" + "\nFile Type: " + fileType);
    }
})