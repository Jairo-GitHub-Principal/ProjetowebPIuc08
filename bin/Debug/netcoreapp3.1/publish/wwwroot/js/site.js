// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function validaform(form){
    
    var nome = document.getElementById("nome");/*recebe o valor dos inputs atraver dos id */
    var msg_nome = document.querySelector(".msg-nome");/* seleciona o seletor na tag span para carregar o elemento span com a msg de erro */

    var msg_erro = document.querySelector(".msg-error")
    msg_nome.style.display="none";

    if(nome.value==""){/*testa os valores recebidos dos inputs */
        msg_nome.innerHTML="Nome: Campo de preenchimento obrigatorio"
        msg_nome.style.display="block";
        msg_erro.style.color="red";
        
        nome.focus();
        return false;

    }


    var endereco= document.getElementById("endereco");
    var msg_endereco = document.querySelector(".msg-endereco");

    msg_endereco.style.display="none"

    if(endereco.value==""){
        msg_endereco.innerHTML="Endereço: Campo de preenchimento obrigatorio"
        msg_endereco.style.display="block"
        endereco.focus();
        return false
    }

    
    
     /* torna obrigatorio o preenchimento como tambem valida o formato de preenchimento do telefone*/
    var telefone = document.getElementById("telefone");
    var msg_telefone= document.querySelector(".msg-telefone");
    

    msg_telefone.style.display="none"
    var expRegTel=/^1\d\d(\d\d)?$|^0800 ?\d{3} ?\d{4}$|^(\(0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d\) ?|0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d[ .-]?)?(9|9[ .-])?[2-9]\d{3}[ .-]?\d{4}$/gm
    if(expRegTel.test(telefone.value)==false){
        msg_telefone.innerHTML="Telefone: tipo de telefone está invalido: "+telefone.value + " Ex: (11)9xxxxYYYY,9xxxxYYYY,xxxxYYYY";
        msg_telefone.style.display="block"
        telefone.focus();
        return false
    }

    
     

   
 

  /* validar seleção de sabor da pizza*/
  var sabor = document.getElementById("sabor");
    if ((sabor.value == "sabor")||(sabor == null)) {
        alert("SABOR: selecione um sabor para continuar");
        return false;
       
    }

    /*validar seleção de tamanho da pizza */
    var tamanho = document.getElementById("Tamanho");
    if ((tamanho.value == "Tamanho")||(tamanho == null)) {
        alert("TAMANHO: selecione um tamanho para continuar");
        return false;
       
    }


    /*validar a radio button */
    
    var radios = document.getElementsByName("pagamento");
    var formValid = false;

    var i = 0;
    while (!formValid && i < radios.length) {
        if (radios[i].checked) formValid = true;
        i++;        
    }

    if (!formValid) alert("Pagamento: selecione uma forma de pagamento");
    return formValid; 
    


    return true;
}
