function StyleGridButtons() {
    $("a[data-edit]").button({
        icons: {
            primary: "ui-icon-pencil"
        },
        text: false
    });
    $("a[data-detail]").button({
        icons: {
            primary: "ui-icon-comment"
        },
        text: false
    });
    $("a[data-delete]").button({
        icons: {
            primary: "ui-icon-trash"
        },
        text: false
    });
    $("a[data-event]").button({
        icons: {
            primary: "ui-icon-clock"
        },
        text: false
    });
}

function SetDateTimePicker() {
    //traduz o calendário
    $('input[type=datetime]').datetimepicker({
        lang: 'de',
        i18n: {
            de: {
                months: [
                 'Janeiro', 'Fevereiro', 'Março', 'Abril',
                 'Maio', 'Junho', 'Julho', 'Agosto',
                 'Setembro', 'Outubro', 'Novembro', 'Dezembro',
                ],
                dayOfWeek: [
                 "Dom", "Seg", "Ter", "Qua",
                 "Qui", "Sex", "Sab",
                ]
            }
        },
        timepicker: true,
        format: 'd/m/Y H:i'
    });
}