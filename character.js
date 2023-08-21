class Character {
    constructor() {
      if (Character.instance) {
        return Character.instance;
      }
      this.qi = 0;
      this.qiElement = document.getElementById("qi");
      this.remainingLife = 60;

      Character.instance = this;
    }

    updateStats() {
        this.qiElement.textContent = this.qi;
    }
  }
  
  const myCharacter = new Character();
  
  export default myCharacter;