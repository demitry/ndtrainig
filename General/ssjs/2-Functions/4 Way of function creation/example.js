 function declarationWay () {
     console.log("This function create at first stage of code processing!" );
 }
 
 var expressionWay = function () {
             console.log("This function create at third stage of code processing - on execution stage!" );
         };
 
 declarationWay();
 expressionWay();
 
 console.log("Both function work good :)");
 