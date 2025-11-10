function listaKeszites(sor)
{
    document.getElementById(sor/10).disabled = true;
    const lista= [];
    for ( let i = 0; i < 5; i++)
    {
        const obj = {id: sor+i, szam: parseInt(document.getElementById(`${sor+i}`).innerText)}
        lista.push(obj);
    }
    return lista;
}

function helyMeghatarozas()
{
    let div = document.getElementById("10");
    let hely = div.getBoundingClientRect();
    console.log(hely.top, hely.right, hely.bottom, hely.left)
    console.log(hely.top);
}

function randomSzam(id)
{
    for (let i = 0; i < 5; i++)
        {
            let kocka = document.getElementById(id+i);
            kocka.innerText = Math.floor(Math.random() * 101);
        }
}

function mozgatasFel(kocka)
{
    let negyzet = document.getElementById(kocka);
    let id = null;
    let pos = negyzet.offsetTop;
    let kezd = pos
    clearInterval(id);
    id = setInterval(frame,5);
    function frame()
    {
        console.log("pos: "+pos);
        if (pos == kezd-200)
        {
            clearInterval(id);
        }
        else
        {
            pos--;
            negyzet.style.top = pos+"px";
        }
    }
}

function mozgatasLe(kocka)
{
    let negyzet = document.getElementById(kocka);
    let id = null;
    let pos = negyzet.offsetTop;
    let kezd = pos
    clearInterval(id);
    id = setInterval(frame,5);
    function frame()
    {
        console.log("pos: "+pos);
        if (pos == kezd+200)
        {
            clearInterval(id);
        }
        else
        {
            pos++;
            negyzet.style.top = pos+"px";
        }
    }
}


function mozgatasOldalra(balKockaId, jobbKockaId)
{
    let balKocka = document.getElementById(balKockaId);
    let jobbKocka = document.getElementById(jobbKockaId);
    let id = null;
    let balPos = balKocka.offsetLeft;
    let jobbPos = jobbKocka.offsetLeft;
    let balKezd = balPos;
    let jobbKezd = jobbPos;
    clearInterval(id);
    id = setInterval(frame,5);
    function frame()
    {
        if (balPos == jobbKezd && jobbPos == balKezd)
        {
            clearInterval(id);
        }
        else
        {
            balPos++;
            jobbPos--;
            balKocka.style.left = balPos+"px";
            jobbKocka.style.left = jobbPos+"px";
            console.log(`bal: ${balKocka.style.left} jobb: ${jobbKocka.style.left}`)
        }
    } 
}

async function egyszeru(sor)
{ 
    let lista = listaKeszites(sor);
    console.log(`Egyszerű: `);
    console.log(lista);

    for (let i = 0; i < lista.length-1; i++)
    {
        let alapKocka = document.getElementById(lista[i].id);
        alapKocka.style.backgroundColor = "green";
        await sleep(1000);
        for (let j = i+1; j< lista.length; j++)
        {
            let vizsgKocka = document.getElementById(lista[j].id);
            vizsgKocka.style.backgroundColor = "red";
            await sleep(1000);
            if (lista[i].szam > lista[j].szam)
            {
                alapKocka.style.backgroundColor = "red";
                mozgatasFel(lista[i].id)
                mozgatasLe(lista[j].id)
                await sleep(1500);
                mozgatasOldalra(lista[i].id,lista[j].id);
                await sleep(1500);
                mozgatasLe(lista[i].id);
                mozgatasFel(lista[j].id);
                await sleep(1500);
                let csere = lista[i];
                lista[i] = lista[j];
                lista[j] = csere;
                alapKocka = document.getElementById(lista[i].id)
                vizsgKocka = document.getElementById(lista[j].id)
                alapKocka.style.backgroundColor = "green";
                console.log(lista);
            }
            vizsgKocka.style.backgroundColor = "cyan";
        }
        alapKocka.style.backgroundColor = "orange";
    }
    document.getElementById(lista[lista.length-1].id).style.backgroundColor = "orange";
    console.log(`Egyszerű(rendezett): `);
    console.log(lista);
}

async function bubbleSort(sor)
{
    let lista = listaKeszites(sor);
    console.log(`bubble sort: `);
    console.log(lista);
    for (let i = lista.length - 1; i > 0; i--)
    {
        for (let j = 0; j < i; j++)
        {
            document.getElementById(lista[j].id).style.backgroundColor = "green";
            document.getElementById(lista[j+1].id).style.backgroundColor = "green";
            await sleep(1000);
            if(lista[j].szam > lista[j+1].szam)
            {
                mozgatasFel(lista[j].id)
                mozgatasLe(lista[j+1].id)
                await sleep(1500);
                mozgatasOldalra(lista[j].id,lista[j+1].id);
                await sleep(1500);
                mozgatasLe(lista[j].id);
                mozgatasFel(lista[j+1].id);
                await sleep(1500);
                let csere = lista[j+1];
                lista[j+1] = lista[j];
                lista[j] = csere;
            }
            document.getElementById(lista[j].id).style.backgroundColor = "cyan";
            document.getElementById(lista[j+1].id).style.backgroundColor = "cyan";
        }
        document.getElementById(lista[i].id).style.backgroundColor = "orange";
    }
    document.getElementById(lista[0].id).style.backgroundColor = "orange";
    console.log(`bubble sort(rendezett): `);
    console.log(lista);
}

async function quickSort_btn(sor)
{
    let lista = listaKeszites(sor);
    quickSort(0,lista.length-1, lista);
}


async function quickSort(also, felso, lista) 
{
    console.log(`quick Sort: `);
    console.log(lista);
    let i = also;
    let j = felso;
    let kozep = lista[Math.floor((felso + also) / 2)];
    document.getElementById(kozep.id).style.backgroundColor = "purple";

    while (also <= felso)
    {
        while ( also < j && lista[also].szam < kozep.szam)
        {
            also++;
        }
        while (felso > i && lista[felso].szam > kozep.szam)
        {
            felso--;
        }
        if (also <= felso)
        {
            if( also != felso)
            {
                document.getElementById(lista[also].id).style.backgroundColor = "red";
                document.getElementById(lista[felso].id).style.backgroundColor = "red";
                mozgatasFel(lista[also].id);
                mozgatasLe(lista[felso].id);
                await sleep(2000);
                mozgatasOldalra(lista[also].id,lista[felso].id);
                await sleep(2000);
                mozgatasLe(lista[also].id);
                mozgatasFel(lista[felso].id);
                await sleep(2000);
                document.getElementById(lista[also].id).style.backgroundColor = "cyan";
                document.getElementById(lista[felso].id).style.backgroundColor = "cyan";

                let csere = lista[also];
                lista[also] = lista[felso];
                lista[felso] = csere;
            }
            ++also;
            --felso;
        }
    }
    document.getElementById(kozep.id).style.backgroundColor = "cyan";
    if (also < j)
    {
        await quickSort(also, j, lista);
    }
    if (felso > i)
    {
       await quickSort(i, felso, lista);
    }

    lista.forEach(e =>{
        document.getElementById(e.id).style.backgroundColor = "orange";
    })
    console.log(`quick Sort(rendezett): `);
    console.log(lista);
}

async function insertionSort(params) 
{
    
}

const rendezes = () =>
{
    let lista = [12,5,7,9,4,30];
    console.log("kezdés: " + lista);
    for (let i = 0; i < lista.length-1; i++)
    {
        for (let j = i+1; j< lista.length; j++)
        {
            if (lista[i] > lista[j])
            {
                let csere = lista[i];
                lista[i] = lista[j];
                lista[j] = csere;
                console.log(lista);
            }
        }
    }
    console.log("vége: "+ lista);
}

function sleep(ms)
{
    return new Promise(resolve => setTimeout(resolve, ms))
}

function init()    
{
    //rendezes();
    randomSzam(10);
    randomSzam(20);
    randomSzam(30);
    //helyMeghatarozas();
}

document.addEventListener("DOMContentLoaded",init);

//ezt ChatGPT csinálta, emiatt vannak középen a négyzetek
window.onload = function() {
  document.querySelectorAll('.anim-div').forEach(div => {
    const boxes = div.querySelectorAll('.anim');
    const boxWidth = 75;
    const boxHeight = 75;
    const gap = 15;
    const totalWidth = boxes.length * (boxWidth + gap) - gap;
    
    const startLeft = (div.offsetWidth - totalWidth) / 2;
    const startTop = (div.offsetHeight - boxHeight) / 2;

    boxes.forEach((box, i) => {
      box.style.left = (startLeft + i * (boxWidth + gap)) + "px";
      box.style.top = startTop + "px";
    });
  });
};
