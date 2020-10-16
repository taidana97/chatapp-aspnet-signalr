var messageBuilder = function(){
    var message = null;
    var header = null;
    var p = null;
    var footer = null;

    return {
        createMessage: function(classList){
            message = document.createElement("div");
            if(classList === undefined)
                classList = [];

            for (let i = 0; i < classList.length; i++) {
                message.classList.add(classList[i]);                        
            }

            message.classList.add('message');

            return this;
        },
        withHeader: function(name){
            header = document.createElement("header");
            header.appendChild(document.createTextNode(name + ":"));

            return this;
        },
        withParagraph: function(text){
            p = document.createElement("p");
            p.appendChild(document.createTextNode(text));

            return this;
        },
        withFooter: function(timestamp){
            footer = document.createElement("footer");
            footer.appendChild(document.createTextNode(timestamp));

            return this;
        },
        build: function(){
            message.appendChild(header);
            message.appendChild(p);
            message.appendChild(footer);

            return message;
        }
    }
}