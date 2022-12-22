// Call the dataTables jQuery plugin
$(document).ready(function () {
    $('#dataTable').DataTable({
        "language": {
            "url": "https://cdn.datatables.net/plug-ins/1.12.1/i18n/tr.json"
        },
        "columnDefs": [
            { "type": "num", "targets": 0 },
            { "targets": 0, "width": "2%" }
        ]
    });
});
