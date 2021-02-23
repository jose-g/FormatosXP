$(document).on('change', '[data-type="cascade-dropdown-list"]', function () {


    var $this = $(this);
    var value = $this.val();
    var dataUpdateTarget = $this.data('update-target');
    var dataFilter = $this.data('filter');
    var dataUrl = $this.data('url');
    var dataHttpMethod = $this.data('http-method');
    var postElement = {};
    postElement[dataFilter] = value;

    $(dataUpdateTarget).attr('disabled', 'disabled')
    $(dataUpdateTarget).find('option[value!=""]').remove();

    $.ajax({
        url: dataUrl,
        dataType: 'JSON',
        method: dataHttpMethod,
        data: postElement,
        async: false,
        crossDomain: true,
        success: function (data) {
            var $$updateTarget = $(dataUpdateTarget)

            var valueMember = 'idamenaza';
            var textMember = 'descripcion';
            for (i = 0; i < data.length; i++) {
                $$updateTarget.append($('<option>').text(data[i][textMember]).attr('value', data[i][valueMember]));
            }

            $$updateTarget.removeAttr('disabled');
        },
        error: function (data, status, xhr) {
            
            alert(xhr.responseText +   "  Sucedio un error, intente mas tarde");
        }
    })


});



$(document).on('change', '[data-type="listbox-dropdown-list"]', function () {


    var $this = $(this);
    var value = $this.val();
    var dataUpdateTarget = $this.data('update-target');
    var dataFilter = $this.data('filter');
    var dataUrl = $this.data('url');
    var dataHttpMethod = $this.data('http-method');
    var postElement = {};
    postElement[dataFilter] = value;

    $(dataUpdateTarget).attr('disabled', 'disabled')
    $(dataUpdateTarget).find('option[value!=""]').remove();

    $.ajax({
        url: dataUrl,
        dataType: 'JSON',
        method: dataHttpMethod,
        data: postElement,
        async: false,
        crossDomain: true,
        success: function (data) {
            var $$updateTarget = $(dataUpdateTarget)

            var valueMember = $$updateTarget.data('value-member')
            var textMember = $$updateTarget.data('text-member')
            for (i = 0; i < data.length; i++) {
                $$updateTarget.append($('<option>').text(data[i][textMember]).attr('value', data[i][valueMember]));
            }

            $$updateTarget.removeAttr('disabled');
        },
        error: function (data, status, xhr) {

            alert("Sucedio un error, intente mas tarde");
        }
    })


});


$('.datatable').dataTable({
    "responsive": true,
    "language": {
        "paginate": {
            "previous": '<i class="fa fa-arrow-left"></i>',
            "next": '<i class="fa fa-arrow-right"></i>'
        },
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        }
    }
});























$('.input-group.date').datepicker({
    setDate: new Date(),
    autoclose: true,
    language: 'es'
});

$('.timepicker').timepicker({
    minuteStep: 5,
    showMeridian: false
});

function createTableJQGrid(element, data, columnNames, colModel) {
    var applicationGrid = element, data;

    applicationGrid.jqGrid({
        datatype: "local",
        colNames: columnNames,
        colModel: colModel,
        rowNum: 10,
        rowList: [10, 20, 30],
        pager: '#pager5',
        sortname: 'id',
        viewrecords: true,
        sortorder: "desc",
        width: "100%",
        height: "100%",
        beforeSelectRow: function (rowid, e) {
            return false;
        },
        multiselect: true
    }).navGrid("#pager5", { edit: false, add: false, del: false });



    for (var i = 0; i <= mydata.length; i++)
        applicationGrid.jqGrid('addRowData', i + 1, mydata[i]);

    applicationGrid.trigger("reloadGrid");


    $(window).on("resize", function () {
        var newWidth = applicationGrid.closest(".ui-jqgrid").parent().width();
        applicationGrid.jqGrid("setGridWidth", newWidth, true);
    });
}

function PostMessage(type, message) {
    var fileTemplate = '<div class="alert alert-' + type + '"><button class="close" data-dismiss="alert"><i class="pci-cross pci-circle"></i></button>' + message + '</div>';
    $('#postMessage').prepend(fileTemplate)

}

function convertFromStringToIntArray(StringValue,separator) {
    var myArray = [];
    var stringArray = StringValue.split(separator)

    for (var i = 0; i < stringArray.length; i++) {
        myArray.push(parseInt(stringArray[i]));
    }
    return myArray;
}

function convertFromStringToStringArray(StringValue, separator) {
    var myArray = [];
    var stringArray = StringValue.split(separator)

    for (var i = 0; i < stringArray.length; i++) {
        myArray.push(stringArray[i]);
    }
    return myArray;
}

function getFormatedDate(date) {
    return date.split('-')[2].substring(0, 2) + '/' + date.split('-')[1] + '/' + date.split('-')[0];
}

