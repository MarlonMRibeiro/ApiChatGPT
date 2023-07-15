<template>
  <div class="fundo-azul"></div>
  <div class="field-text-area">
    <div class="card-text-area">
      <Textarea placeholder="Texto" @input="atualizarTexto" v-model="textoOriginal"></Textarea>
      <div class="bottom-text-area">
          <Button label="Upload" icon="fas fa-upload" :loading="loading" @click="load" plain text />
          <Button label="Limpar" icon="fas fa-trash" :loading="loading" @click="load" plain text />
          <Button label="Gravar" icon="fas fa-microphone" :loading="loading" @click="load" plain text />
      </div>
    </div>
    <div class="card-text-area">
      <Textarea v-model="textoResumido" v-bind:value="textoResumido"> </Textarea>
      <div style="width: 100%; height: 15%; display: flex; justify-content: space-around;">
        <Button label="Download" icon="fas fa-download" :loading="loading" @click="load" plain text />
        <Button label="Copiar" icon="fas fa-copy" :loading="loading" @click="load" plain text />
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
      textoOriginal: "asdasfsdfsadf",
      textoResumido: ""
    }
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
</style>
