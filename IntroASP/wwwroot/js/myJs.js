console.log("Bienvenido a tu primer proyecto Full Stack!")



let content = ``;

const URL = "https://localhost:7250/Venta";

const getBeers = async () =>
{
    return new Promise((resolve,rejected)=>{
        const xhr = new XMLHttpRequest();
        xhr.addEventListener("readystatechange", ()=>{
            if(xhr.readyState == 4){
                if(xhr.status >= 200 && xhr.status < 300){
                    const data = xhr.responseText;
                    content = data;
                    console.log(content);
                    resolve(data);
                }else{
                    console.error(`Error: ${xhr.status} - ${xhr.statusText}`);
                    rejected("Error: No se encontro la lista de birras");
                }
            }
        });

        xhr.open("GET", URL);
        xhr.send();
    });
};

let btn = document.getElementById("runJs");
btn.addEventListener('click', getBeers);

let show = document.getElementById("showJs");
show.addEventListener('click', showData);

function showData(){
    let div = document.getElementById('content');
    let divSon = document.createElement('div');
    divSon.innerHTML = content;
    div.appendChild(divSon);
}

