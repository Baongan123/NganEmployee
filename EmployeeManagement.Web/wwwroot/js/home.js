var home = {} || home;

home.drawTable = function () {
    $.ajax({
        url: "/Home/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbDepart tbody').empty();
            $.each(data.departments, function (i, v) {
                var emps = v.employees > 0 ?
                    `<a href="/Employee/List/${v.departmentId}" title="Employee list">${v.employees}</a>` :
                    `${v.employees}`;
                $('#tbDepart tbody').append(
                    `<tr>
                        <td>${v.departmentId}</td>
                        <td>${v.departmentName}</td>
                        <td>${emps}</td>
                        <td>
                            <a href="javascripts:;" class="btn btn-success"
                                       onclick="home.get(${v.departmentId})">Edit</a> 
                            <a href="javascripts:;" class="btn btn-danger"
                                        onclick="home.delete(${v.departmentId})">Remove</a>
                        </td>
                    </tr>`
                );
            });
        }
    });

};

home.openAddEditdepartment = function () {
    home.reset();
    $('#addEditdepartment').modal('show');
};


home.delete = function (id) {
    bootbox.confirm({
        title: "Delete department?",
        message: "Do you want to delete this department.",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> No'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Yes'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Home/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        home.drawTable();
                    }
                });
            }
        }
    });
}


home.get = function (id) {
    $.ajax({
        url: `/Home/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#DepartmentName').val(data.result.departmentName);
            $('#DepartmentId').val(data.result.departmentId);
            $('#addEditdepartment').modal('show');
        }
    });
}

home.reset = function () {
    $('#DepartmentName').val("");
    $('#DepartmentId').val(0);
}

home.save = function () {
    var saveObj = {};
    saveObj.DepartmentName = $('#DepartmentName').val();
    saveObj.DepartmentId = parseInt($('#DepartmentId').val());
    $.ajax({
        url: `/Home/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditdepartment').modal('hide');
            bootbox.alert(data.result.message);
            home.drawTable();
        }
    });
}

home.init = function () {
    home.drawTable();
};

$(document).ready(function () {
    home.init();
});