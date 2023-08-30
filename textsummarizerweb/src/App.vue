<template>
  <div class="fundo-azul"></div>
  <div class="field-text-area">
    <div class="card-text-area">
      <Textarea placeholder="Texto" @input="atualizarTexto" v-model="textoOriginal" v-bind:value="textoOriginal"></Textarea>
      <div class="bottom-text-area">
          <Button label="Upload" icon="fas fa-upload" :loading="loading" @click="load" plain text />
          <Button label="Limpar" icon="fas fa-trash" :loading="loading" @click="limpar" plain text />
          <Button class="btn-microphone" label="Gravar" icon="fas fa-microphone" :loading="loading" @click="clickMicrofone" plain text />
      </div>
    </div>
    <div class="card-text-area">
      <Textarea v-model="textoResumido" :readonly="true" v-bind:value="textoResumido" id="textarea"> </Textarea>
      <div style="width: 100%; height: 15%; display: flex; justify-content: space-around;">
        <Button label="Download" icon="fas fa-download" :loading="loading" @click="load" plain text />
        <Button label="Copiar" icon="fas fa-copy" :loading="loading" @click="copiarTexto" plain text />
      </div>
    </div>
  </div>
  <p>O valor do text area é: {{ textoOriginal }}</p>
</template>
<script>
import Button from "primevue/button"

export default {
  name: 'App',
  data() {
    return {
      textoOriginal: "a",
      textoResumido: "dfsgdsfgdsfg",
      recognition: null,
      listening: false
    }
  },
  mounted: function() {
    this.recognition = this.createRecognition();
  },
  methods: {
    atualizarTexto(event) {
      this.textoOriginal = event.target.value;
      this.textoResumido = this.integraAPI(this.textoOriginal);
    },
    integraAPI(text){
      this.$http.post('https://localhost:7273/Chat?role=asdf&content=' + text).then(res => {
        this.textoResumido = res
      })
      .catch(e => 
      {
        console.log(e)
      })
    },
    limpar(){
      this.textoOriginal = "";
    },
    copiarTexto() {
        navigator.clipboard.writeText(this.textoResumido);
    },
    createRecognition(){
      const SpeechRecognition = window.SpeechRecognition || window.webkitSpeechRecognition;
      const recognition = SpeechRecognition !== undefined ? new SpeechRecognition() : null;

      if(!recognition){
        return
      }

      recognition.lang = "pt_BR";
      recognition.continuous = true;

      recognition.onstart = () => { 
        this.listening = true;
        document.getElementsByClassName("btn-microphone")[0].children[0].classList.add("send");
      };

      recognition.onend = () => { 
        this.listening = false;
        document.getElementsByClassName("btn-microphone")[0].children[0].classList.remove("send");
      };
      recognition.onerror = e => console.log("error", e);
      recognition.onresult = e => this.textoOriginal = e.results[0][0].transcript;
      return recognition;
    },
    clickMicrofone(){
      if(!this.recognition) return;

      this.listening ? this.recognition.stop() : this.recognition.start();

    }
  },
  components: {
    Button
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

body{
  margin: 0;
}

textarea {
  border: none;
  background-color: transparent;
  resize: none !important;
  outline: none;
  width: 100%; 
  padding: 15px; 
  height: 85%;
  border: 0;
}

.p-button {
    color: #ffffff;
    background: #6366F1;
    border: 0 !important;
    padding: 0.75rem 1.25rem;
    font-size: 1rem;
    transition: background-color 0.2s, color 0.2s, border-color 0.2s, box-shadow 0.2s;
    border-radius: 6px;
}

.p-button:hover {
  background: 0 !important;
}

.p-button:focus {
  box-shadow: none !important;
}

.fundo-azul {
  background-color: rgb(59, 183, 255); 
  width: 100%;
  height: 300px; 
  margin-bottom: -170px;
}

.field-text-area {
  display: flex; 
  text-align: center; 
  justify-content: space-evenly; 
  margin: 0px 150px;
}

.card-text-area {
  border:rgb(143, 143, 143) solid 1px; 
  width: 500px; 
  border-radius: 15px; 
  height: 300px; 
  background-color: white;
}

.bottom-text-area {
  width: 100%; 
  height: 15%; 
  display: flex; 
  justify-content: space-around;
}

/* TESTEeeeeeeeeeeeeeeeeeeeeeee */

.send {
  border-radius: 70px;
  box-shadow: 0 0 0 0 rgba(69, 152, 27, 0.5);
  cursor: pointer;
  outline: none;
  padding: 1px 1px;
  transition: background, padding 1ms ease-in-out;
  animation: pulse 1.5s infinite;
}

@keyframes pulse {
  0% {
    transform: scale(.2);
  }

  70% {
    transform: scale(1);
    box-shadow: 0 0 0 12px rgba(69, 152, 27, 0);
  }
}

</style>
