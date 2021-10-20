// api url
const api_url =
  "http://localhost:29460/api/Notes/";

var cardList;
var CardAddNote = document.getElementById('CardAddNote');
var Modal = document.getElementById('modalNote');
var ModalTextArea = document.getElementById('message-text');
var ButtonSave = document.getElementById('btnSaveEdit');

var TextAdd = document.getElementById('TextAdd');
var FormAddNote = document.getElementById('FormAddNote');
var textarea = document.getElementById('textarea');
var checkAdding = false;



function hideloader() {
  document.getElementById('loading').style.display = 'none';
}

async function getapi(url) {

  const response = await fetch(url);
  var data = await response.json();

  if (response) {
    hideloader();
  }
  cardList = data.data;
  showCards();
  
}
getapi(api_url);

async function callAdd() {
  if (textarea.value != '') {
    var note = {
      Id: 0,
      Text: textarea.value
    };
    var jsonData = JSON.stringify(note)
    const response = await fetch(api_url, {
      method: 'POST',
      body: jsonData,
      headers: {
        'Content-Type': 'application/json'
      },
      dataType: 'json',
    });
    var data = await response.json();
   
    if (response) {
      hideloader();
      cardList.push(data.data);
      showCards();
      
    }
   
  }
}
async function callDelete(id) {

  const response = await fetch(api_url + id, {
    method: 'DELETE',
  });
  var data = await response.json();

  if (response) {
    hideloader();
    deleteById(id);   
  }


}
function deleteById(id) {
  var ident = parseInt(id);
  cardList.forEach(function (currentValue, index, arr) {
    if (cardList[index].id == ident) {
      cardList.splice(index, 1);
    }
  })

  showCards();
}

function getItem(id) {
  var ident = parseInt(id);
  var dataNote =
    cardList.find(item => item.id === ident);
  return dataNote;
}
async function callEdit() {

  var note = getItem(ButtonSave.name);
  note.text = ModalTextArea.value;
  var jsonData = JSON.stringify(note)
  const response = await fetch(api_url, {
    method: 'PUT',
    body: jsonData,
    headers: {
      'Content-Type': 'application/json'
    },
    dataType: 'json',
  });
  var data = await response.json();
  if (response) {
    hideloader();
    editCardList(note);
    Modal.style = ('display: none');
    showCards();
  }


}
function editCardList(note)
{
  for (var i = 0; i < cardList.length; i++) {
    if (cardList[i].Id === note.id) {
      cardList[i].text = note.text;
      break;
    }
  }

}
function showCards() {
  let cards =
    ``;
  let lisOrderDesc = cardList.sort(function (a, b) {
    if (a.id < b.id) {
      return 1;
    }
    if (a.id > b.id) {
      return -1;
    }
    return 0;
  });

  for (let r of lisOrderDesc) {
    cards += newCard(r);
  }
  CardAddNote.style = ('display: block');
  document.getElementById("notes").innerHTML = cards;
}

function newCard(r) {
  var date = r.dateCreation;
  var dateCardCreation = new Date(date).toLocaleString("en-US", { timeZone: "America/New_York" });

  return `
      <div class="card cardShow">
        <div class="card-body" data-toggle="modal" data-target="#modalNote" data-whatever=${r.id}>
           <p>${r.text}</p>           
        </div>
        <div class="card-footer d-flex justify-content-end">
           <span style="color:dimgray;">Create ${dateCardCreation}</span>          
           <i onclick="callDelete(${r.id})" id="iconCard" class="fa fa-trash"></i>
        </div>
      </div>
`;

}

CardAddNote.addEventListener('click', function () {
  TextAdd.style = ('display: none');
  FormAddNote.style = ('display: block'); 
  textarea.style = ('animation: riseHeight 0.5s .1s normal forwards');  
  checkAdding = true;
  textarea.focus();
})

document.addEventListener('mouseup', function (e) {
  if (!CardAddNote.contains(e.target) && checkAdding) {
    checkAdding = false;
    callAdd();
    textarea.value = '';
    TextAdd.style = ('display: block');
    FormAddNote.style = ('display: none');   
  }
});

$('#modalNote').on('show.bs.modal', function (event) {
  var card = $(event.relatedTarget) 
  var recipient = card.data('whatever')

  var note = getItem(recipient);

  ModalTextArea.value = note.text;
  ButtonSave.name = recipient;

  
})