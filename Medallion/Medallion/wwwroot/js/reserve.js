// console.log(document.getElementById('diagram2'))
document.getElementById('diagram2').innerHTML = document.getElementById('diagram').innerHTML
document.getElementById('diagram').style.display = "none" 
let seatData = JSON.parse(document.getElementById("seatData").innerText)

console.log(seatData);
let oldSeats = []
let txtpId = document.getElementById('performanceId');
txtpId.addEventListener('change', () => {
    let choosenSeats = seatData.filter(s => s.performance.id == txtpId.value.trim())
    for (let i = 0; i < choosenSeats.length; i++) {
        choosenSeats[i].section = choosenSeats[i].section.toLowerCase(); 
        let num = parseInt(choosenSeats[i].number.trim())
        if (choosenSeats[i].section.trim() == "X") {
            if (num <= 8) {
                
                document.getElementByClassName("box")[0].children[num - 1].style.backgroundColor = "grey"
            }
            else {
                document.getElementByClassName("box")[1].children[num - 1].style.backgroundColor = "grey"
            }
        }
        else {
            console.log(choosenSeats[i].section.trim())
            Array.from(document.getElementById(choosenSeats[i].section.trim()).children).filter((child) => child.className == "seat")[num - 1].style.backgroundColor = "grey"
        }

    }
})
let seats = document.getElementsByClassName('seat')
for(i=0;i<seats.length;i++){
    seats[i].addEventListener('click',(e)=>{
        // console.log(e.target )
        if(e.target.style.backgroundColor != "grey"){
            if (e.target.parentElement.className.includes("box")) {
                //e.target.style.backgroundColor = "grey"
                document.getElementById('price').value = parseInt(document.getElementById('price').value) +85
                // document.getElementById("txt_seat").
                let boxElements1 = document.getElementsByClassName('box')[0].children;
                let boxElements2 = document.getElementsByClassName('box')[1].children;
                
                for(j=0;j<=boxElements1.length;j++){
                    if(boxElements1[j]==e.target){
                        document.getElementById("txt_seat").value += ",X"+" "+(j+1)
                    }
                    if(boxElements2[j]==e.target){
                        document.getElementById("txt_seat").value += ",X"+" "+(j+8+1)
                    }
                }

            }
            else if (e.target.parentElement.parentElement.className == "orchestra") {
                document.getElementById('price').value = parseInt(document.getElementById('price').value)+65
                
            }
            else if(e.target.parentElement.parentElement.className == "mezzanine" ){
                document.getElementById('price').value = parseInt(document.getElementById('price').value) + 55
            }
            else if(e.target.parentElement.parentElement.className == "balcony" ){
                document.getElementById('price').value = parseInt(document.getElementById('price').value) + 40
            }

            if(!(e.target.parentElement.className.includes("box"))){
                let children = document.getElementsByClassName(e.target.parentElement.className)[0].children
                let rowElements = Array.from(children).filter((child) => child.className == "seat" )
                for (j = 0; j < rowElements.length; j++){
                    if (rowElements[j] === e.target) {
                        document.getElementById("txt_seat").value+=","+(e.target.parentElement.className.toUpperCase())+" "+(j+1)
                    }
                }
            }
        }
    })
}

function findRowCol(element){
    
}


