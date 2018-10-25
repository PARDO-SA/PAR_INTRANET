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
        dom: 'Bfrtip',
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
        "scrollCollapse": true,
        "info": false,
        "paging": false
    });

    $('#tablaComiArt').dataTable({
        "paging": false,
        "searching": false,
        "info": false,
        "ordering": false
    });
});