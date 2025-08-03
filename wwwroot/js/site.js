// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



     document.addEventListener('DOMContentLoaded', function () {
        document.querySelectorAll('.preco-input').forEach(function (input, idx) {
            input.addEventListener('input', function (e) {
                let value = e.target.value.replace(/\D/g, '');
                let floatValue = 0;
                if (value.length > 0) {
                    floatValue = parseFloat(value) / 100;
                    e.target.value = floatValue.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2, style: "currency", currency: "BRL" });
                } else {
                    e.target.value = '';
                }
                // Busca o input  correspondente pelo índice
                let p = document.getElementById('preco-' + idx);
                
                if (p) {
                    p.value = floatValue/*.toString().replace(',', '.'); *//*|| ''*//*;*/

                } 
            });
        });
});

//document.addEventListener('DOMContentLoaded', function () {
//    document.querySelectorAll('.preco-input').forEach(function (input, idx) {
//        input.addEventListener('input', function (e) {
//            // Remove tudo exceto dígitos e vírgula
//            let value = e.target.value.replace(/[^\d,]/g, '');
//            // Converte vírgula para ponto para decimal
//            let floatValue = 0;
//            if (value.length > 0) {
//                // Se houver vírgula, converte para ponto
//                value = value.replace(',', '.');
//                floatValue = parseFloat(value);
//                // Formata para exibição com R$
//                e.target.value = floatValue.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
//            } else {
//                e.target.value = '';
//            }
//            // Envia para o hidden o valor decimal com ponto
           
//            let p = document.getElementById('preco-' + idx);
//            console.log(floatValue);
//            console.log(p)
//            if (p) {
//                p.value = floatValue || '';
//            }
//        });
//    });
//});
