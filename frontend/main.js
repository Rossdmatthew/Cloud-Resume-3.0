window.addEventListener('DOMContentLoaded', (event) =>{
    getvisitCount();
})

const functionApi='';

const getvisitCount = () => {
        let count= 30;
        fetch (functionAPI).then(response => {
            return repsonse.json()
        }).then(response =>{
            console.log("Website called function API.");
            count = response.count;
            document.getElementById("counter").innerText = count;
        }).catch(function(error){
            console.log(error);
        });
        return count;
}