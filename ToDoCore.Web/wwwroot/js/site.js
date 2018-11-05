$(function () {

    $('#txtSearch').keypress(function (e) {
        //if (e.which === 13) {
        var searchText = $('#txtSearch').val();
        $.ajax({
            url: 'ToDo/Search',
            type: 'POST',
            data: { 'keyword': searchText },
            success: function (htmlvalue) {
                $('#divToDoList').html(htmlvalue);
            }
        });
        //}
    });
    $(".createToDo").click(function () {
        var serializeItem = $('#frmToDo').serialize();
        $.ajax({
            url: '/ToDo/Create',
            type: 'POST',
            content: 'application/json;',
            dataType: 'json',
            data: serializeItem,
            success: function (data) {
                window.location.href = '/ToDo/Edit/' + data.id;
            },
            error: function (xhr, status, error) {
                alert('failure:' + error);
            }
        });
    });
    $(".updateToDo").click(function () {
        var serializeItem = $('#frmToDo').serialize();
        $.ajax({
            url: '/ToDo/Edit',
            type: 'POST',
            content: 'application/json;',
            dataType: 'json',
            data: serializeItem,
            success: function (data) {
                alert('asdasd');
                //window.URL = '/ToDo/Edit/' + todoItem.Id;
            }
        });
    });

    $(".taskModalPopup").click(function () {
        var buttonClicked = $(this);
        var id = $(this).data('taskid');
        var todoid = $(this).data('todoid');
        var options = {
            "backdrop": "static",
            keyboard: true
        };
        $.ajax({
            type: "GET",
            url: '/ToDo/TaskModal',
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: {
                'id': id,
                'todoid': todoid
            },
            success: function (data) {
                $('#myModalContent').html(data);
                //$('#myModal').modal(options);
                $('#myModal').modal('show');
            },
            error: function () {
                alert("Content load failed.");
            }
        });
    });

    $(".reminderModalPopup").click(function () {
        var buttonClicked = $(this);
        var id = $(this).data('reminderid');
        var taskid = $(this).data('taskid');
        var options = {
            "backdrop": "static",
            keyboard: true
        };
        $.ajax({
            type: "GET",
            url: '/ToDo/ReminderModal',
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            data: {
                'id': id,
                'taskid': taskid
            },
            success: function (data) {
                $('#myModalContent').html(data);
                //$('#myModal').modal(options);
                $('#myModal').modal('show');
            },
            error: function () {
                alert("Content load failed.");
            }
        });
    });

    $("#closbtn").click(function () {
        debugger;
        $('#myModal').modal('hide');
    });

    //$("#btnEdit").click(function () {
    //    alert('Edit');
    //});
});