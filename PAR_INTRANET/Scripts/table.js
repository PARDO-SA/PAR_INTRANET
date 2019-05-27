$(document).ready(function () {
    $('#tabla').dataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                className: 'btn-nuevo',
                action: function() {
                    location.href = '/empleado/create';
                }
            },
            {
                text:'',
                extend: 'excel',
                className: 'btn-excel',
                titleAttr: 'Excel'
            },
            {
                text: '',
                extend: 'pdf',
                className: 'btn-pdf',
                titleAttr: 'Pdf'

            },
            {
                text: '',
                extend: 'print',
                className: 'btn-print',
                titleAttr: 'Imprimir'

            },
        ],
        "language": {
            //"url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json",
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando _START_ al _END_ de _TOTAL_ registros ",
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
        },
        "LengthChange": false,
        "pageLength": 20,
    });

    $('#tablaComi').dataTable({
        dom: 'Bfrti',
        buttons: [
            {
                className: 'btn-nuevo',
                action: function () {
                    location.href = '/Comisiones/create';
                }
            },
            {
                text: '',
                extend: 'excel',
                className: 'btn-excel',
                titleAttr: 'Excel'
            },
            {
                text: '',
                extend: 'pdf',
                className: 'btn-pdf',
                titleAttr: 'Pdf'
            },
            {
                text: '',
                extend: 'print',
                className: 'btn-print',
                titleAttr: 'Imprimir'
            },
        ],
        "language": {
            //"url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json",
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando _START_ al _END_ de _TOTAL_ registros ",
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
        },
        "lengthChange": false,
        "scrollX": true,
        //"scrollY": "380px",
        //"scrollCollapse": false,
        //"pageLength": 20,
        "paging": false
    });

    $('#tablaEstadoTX').dataTable({
        dom: 'Blrti',
        "columnDefs": [
            {
                "orderable": false,
                "targets": [0, 3, 4, 5, 7, 8, 9, 11, 12, 13, 14]
            }
        ],
        "buttons": [
            {
                className: 'btn-refresh',
                action: function () {
                    $.ajax({
                        url: "EstadoSucursales/EstadoTx",
                        type: "get",
                        //data: $("form").serialize(), //if you need to post Model data, use this
                        success: function (result) {
                            $("#estadoTX").html(result);
                        }
                    });
                }
            },
        ],
        "lengthChange": false,
        //"scrollX": true,
        //"scrollCollapse": true,
        "searching": false,
        "paging": false
    });
});