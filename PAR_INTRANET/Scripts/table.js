$(document).ready(function () {
    // Disable search and ordering by default
    $.extend($.fn.dataTable.defaults, {
        "processing": true,
        "language": {
            //"url": "//cdn.datatables.net/plug-ins/1.10.16/i18n/Spanish.json",
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ registros",
            "sZeroRecords": "No se encontraron resultados",
            "sEmptyTable": "Ningún dato disponible en esta tabla",
            "sInfo": "Mostrando _START_ al _END_ de _TOTAL_ registros ",
            "sInfoEmpty": "",
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

    $('#tablaEmpleados').dataTable({
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
        "LengthChange": false,
        "pageLength": 20,
    });

    $('#tablaComisiones').dataTable({
        dom: 'Bfrtip',
        buttons: [
            {
                className: 'btn-nuevo',
                action: function () {
                    location.href = '/Comisiones/Create';
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
        "paging": false,
        columnDefs: [
            { targets: [8, 9, 10], orderable: false },
        ],
        fixedColumns: {
            leftColumns: 0,
            rightColumns: 3
        }
    });

    $('#tablaResumenComisiones').dataTable({
        dom: 'Bfrti',
        "order": [[0, "asc"]],
        "ordering": false,
        buttons: [
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
        columnDefs: [
            { targets: [0], searchable: true },
            { targets: '_all', searchable: false },
            { targets: [0], visible: false, }
        ],
        "paging": false,
        "drawCallback": function (settings) {
            var api = this.api();
            var rows = api.rows({ page: 'current' }).nodes();
            var last = null;
            var colonne = api.row(0).data().length;
            var totale = new Array();
            totale['Totale'] = new Array();
            var groupid = -1;
            var subtotale = new Array();

            api.column(0, { page: 'current' }).data().each(function (group, i) {
                if (last !== group) {
                    groupid++;
                    $(rows).eq(i).before(
                        '<tr class="group"><td>' + group + '</td></tr>'
                    );
                    last = group;
                }

                val = api.row(api.row($(rows).eq(i)).index()).data();      //current order index
                $.each(val, function (index2, val2) {
                    if (typeof subtotale[groupid] == 'undefined') {
                        subtotale[groupid] = new Array();
                    }
                    if (typeof subtotale[groupid][index2] == 'undefined') {
                        subtotale[groupid][index2] = 0;
                    }
                    if (typeof totale['Totale'][index2] == 'undefined') { totale['Totale'][index2] = 0; }

                    //valore = Number(val2.replace('€', "").replace('.', "").replace(',', "."));
                    valore = Number(val2.replace('.', "").replace(',', "."));
                    subtotale[groupid][index2] += valore;
                    totale['Totale'][index2] += valore;
                });
            });

            $('tbody').find('.group').each(function (i, v) {
                var rowCount = $(this).nextUntil('.group').length;
                $(this).find('td:first').append($('<span />', { 'class': 'rowCount-grid' }).append($('<b />', { 'text': ' (' + rowCount + ')' })));
                var subtd = '';
                for (var a = 2; a < colonne; a++) {
                    //subtd += '<td>' + subtotale[i][a] + ' OUT OF ' + totale['Totale'][a] + ' (' + Math.round(subtotale[i][a] * 100 / totale['Totale'][a], 2) + '%) ' + '</td>';
                    if (Number.isNaN(subtotale[i][a])){
                        subtd += '<td></td>';
                    } else {
                        subtd += '<td>' + subtotale[i][a] + '</td>';
                    }
                }
                $(this).append(subtd);
            });
        }
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
        //"scrollX": true,
        //"scrollCollapse": true,
        "searching": false,
        "paging": false
    });

    $('#tablaVtexOrder').dataTable({
        dom: 'Bfrtip',
        "deferRender": true,
        buttons: [
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
        "LengthChange": false,
        "pageLength": 20,
    });

    $('#tablaVtexOrderItems').dataTable({
        dom: 'Blrti',
        "columnDefs": [
            {
                "orderable": false,
            }
        ],
        "lengthChange": false,
        //"scrollX": true,
        //"scrollCollapse": true,
        "searching": false,
        "paging": false
    });

    // Collapse / Expand Click Groups
    $('.grid tbody').on('click', 'tr.group', function () {
        var rowsCollapse = $(this).nextUntil('.group');
        $(rowsCollapse).toggleClass('hidden');
    });

});