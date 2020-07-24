var employee = {} || employee;
var departId = 0;

employee.drawTable = function () {
    
    $.ajax({
        url: `/Employee/Gets/${departId}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbEmployee tbody').empty();
            $.each(data.employees, function (i, v) {
                $('#tbEmployee tbody').append(
                    `
                    <tr>
                        <td>${v.employeeId}</td>
                        <td>${v.employeeName}</td>
                        <td>${v.doB}</td>
                        <td>${v.gender}</td>
                        <td>${v.avatarPath}</td>
                        <td>${v.createdDate}</td>
                        <td>
                            <a href="javascripts:;" onclick="employee.get(${v.employeeId})" class="btn btn-success">Edit</a> 
                            <a href="javascripts:;" onclick="employee.delete(${v.employeeId})" class="btn btn-danger">Remove</a>
                        </td>
                    </tr>
                    `
                );
            });
        }
    });

};

employee.openAddEditemployee = function () {
    employee.reset();
    $('#addEditemployee').modal('show');
};


employee.delete = function (id) {
    bootbox.confirm({
        title: "Delete employee?",
        message: "Do you want to delete this employee.",
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
                    url: `/Employee/Delete/${id}`,
                    method: "GET",
                    dataType: "json",
                    success: function (data) {
                        bootbox.alert(data.result.message);
                        employee.drawTable();
                    }
                });
            }
        }
    });
}


employee.get = function (id) {
    $.ajax({
        url: `/Employee/Get/${id}`,
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#EmployeeName').val(data.result.employeeName);
            $('#EmployeeId').val(data.result.employeeId);
            $('#DoB').val(convert(data.result.doB));
            employee.initGender(data.result.gender);
            employee.initDepartment();
            $('#AvartarPath').val(data.result.avatarPath);
            $('#addEditemployee').modal('show');
        }
    });
}

employee.reset = function () {
    $('#EmployeeName').val("");
    $('#EmployeeId').val(0);
    $('#DoB').val("");
    $('#Gender').val("");
    $('#DepartmentId').val("");
    $('#AvatarPath').val("");
    $('#IsDeleted').val(0);
}

employee.save = function () {
    var saveObj = {};
    saveObj.EmployeeId = parseInt($('#EmployeeId').val());
    saveObj.EmployeeName = $('#EmployeeName').val();
    saveObj.DoB = $('#DoB').val();
    saveObj.Gender = $('#Gender').val();
    saveObj.DepartmentId = parseInt($('#Department').val());
    saveObj.AvatarPath = "img";
   

    $.ajax({
        url: `/Employee/Save/`,
        method: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(saveObj),
        success: function (data) {
            $('#addEditemployee').modal('hide');
            bootbox.alert(data.result.message);
            employee.drawTable();
        }
    });
}
employee.initGender = function (gender) {
    $('#Gender').empty();
    if (gender == "Male") {
        $('#Gender').append(`<option value="true" selected>Male</option>`).append(`<option value="false">Female</option>`)
    } else {
        $('#Gender').append(`<option value="true" >Male</option>`).append(`<option value="false" selected>Female</option>`)
    }

}
employee.initDepartment = function () {
    $.ajax({
        url: "/Home/Gets",
        method: "GET",
        dataType: "json",
        success: function (data) {
            $('#tbDepart tbody').empty();
            $('#Department').empty();
            $.each(data.departments, function (i, v) {
                let selected = v.departmentId == departId ? "selected" : "";
                $('#Department').append(`<option value="${v.departmentId}" ${selected}>${v.departmentName}</option>`)
            });
        }
    });
}
employee.init = function () {
    employee.drawTable();
    employee.initGender("Male");
    employee.initDepartment();
};
function convert(str) {
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [date.getFullYear(), mnth, day].join("-");
}

$(document).ready(function () {
    departId = $('#DepartmentId').val();
    employee.init();
});