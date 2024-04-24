// console.log(document.getElementById('diagram2'))
document.getElementById('diagram2').innerHTML = document.getElementById('diagram').innerHTML
document.getElementById('diagram').style.display = "none" 

let seats = document.getElementsByClassName('seat')
for(i=0;i<seats.length;i++){
    seats[i].addEventListener('click',(e)=>{
        console.log(e.target )
        if(e.target.style.backgroundColor != "grey"){
            if(e.target.parentElement.className.includes("box") ){
                document.getElementById('price').value = "85"
                // document.getElementById("txt_seat").
                let boxElements = document.getElementsByClassName('box')[0].children;
                for(j=0;j<=boxElements.length;j++){
                    if(boxElements[j]==e.target){
                        document.getElementById("txt_seat").value="X"+j
                    }
                    console.log(boxElements[j])
                    let once = true
                    if((j+1==boxElements.length)&&(once) ){
                        once=false
                        boxElements = document.getElementsByClassName('box')[1].children;
                        j=-1
                    }
                }

                console.log(boxElements)
            }
            else if(e.target.parentElement.parentElement.className == "orchestra" ){
                document.getElementById('price').value = "65"
                
            }
            else if(e.target.parentElement.parentElement.className == "mezzanine" ){
                document.getElementById('price').value = "55"
            }
            else if(e.target.parentElement.parentElement.className == "balcony" ){
                document.getElementById('price').value = "40"
            }
        }
    })
}

function findRowCol(element){
    
}


