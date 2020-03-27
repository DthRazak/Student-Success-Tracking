var getStudentsByGroup = function (group) {
    $.ajax({
        type: "GET",
        url: "/Account/GetStudentsByGroup",
        data: 'group=' + group,
        success: function (data) {
            var selTag = document.getElementById("fullNameSelect");
            selTag.textContent = '';
            var d = $.parseJSON(data);
            for (let i = 0; i < d.Students.length; ++i) {
                var op = document.createElement('option');
                op.value = d.Students[i]["Id"];
                op.textContent = d.Students[i]["FullName"];
                selTag.appendChild(op)
            }
        },
        error: function (data) {
            console.log(data);
        }
    });
};

var getLectors = function () {
    $.ajax({
        type: "GET",
        url: "/Account/GetLectors",
        success: function (data) {
            var selTag = document.getElementById("fullNameSelect");
            selTag.textContent = '';
            var d = $.parseJSON(data);
            for (let i = 0; i < d.Lectors.length; ++i) {
                var op = document.createElement('option');
                op.value = d.Lectors[i]["Id"];
                op.textContent = d.Lectors[i]["FullName"];
                selTag.appendChild(op)
            }
        },
        error: function (data) {
            console.log(data);
        }
    });
};

$("#GroupSelect").change(function () {
    let group = document.getElementById("GroupSelect").value;
    getStudentsByGroup(group);
});

$('.form-check-input').change(function () {
    var selected_value = $("input[name='inlineRadioOptions']:checked").val();
    if (selected_value == "option1") {
        $("#groupDiv").show();
        $("#nameSelectLabel").text("Select Student");
        $("#fullNameSelect").attr("name", "StudentId");
        $("#signupForm").attr("action", "/Account/SignupAsStudent");
    } else {
        $("#groupDiv").hide();
        $("#nameSelectLabel").text("Select Lector");
        $("#fullNameSelect").attr("name", "LectorId");
        $("#signupForm").attr("action", "/Account/SignupAsLector");
        getLectors();
    }
});