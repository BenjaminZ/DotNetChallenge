<template>
    <div class="main">
        <div id="inputs">
            <h1 class="heading">.Net Challenge</h1>
            <label for="name" class="input-container">
            <span>
                Name
                <span class="required">*</span>
            </span>
                <input name="name" id="name" type="text" v-model="name"/>
            </label>
            <label for="amount" class="input-container">
            <span>
                Amount
                <span class="required">*</span>
            </span>
                <input name="amount" id="amount" type="number" v-model="amount"/>
            </label>
            <div class="input-container">
                <span>&nbsp;</span>
                <div class="buttons">
                    <input type="submit"
                           class="button submit"
                           value="convert"
                           v-on:click="convert">
                    <input type="submit"
                           class="button clear"
                           value="clear"
                           v-on:click="clear">
                </div>
            </div>
        </div>
        <div class="display-box">
            <span v-if="response.name">{{response.name}}</span>
            <span v-if="response.amountString">{{response.amountString}}</span>
            <span v-if="response.message">{{response.message}}</span>
            <div v-if="errors.length">
                <b>Please correct the following errors:</b>
                <ul>
                    <li v-for="error in errors">{{error}}</li>
                </ul>
            </div>
        </div>
    </div>
</template>

<script>
    import ConversionResponse from './model/ConversionResponse'
    import Axios from 'axios';

    export default {
        data: function () {
            return {
                name: null,
                amount: null,
                response: {},
                errors: [],
            }
        },
        methods: {
            convert: function () {
                this.clear();
                this.amount = parseInt(this.amount);
                if (!this.validate())
                    return;
                Axios.get(`https://localhost:5001/api/conversion?amount=${this.amount}&name=${this.name}`,
                    {
                        headers: {
                            'Content-Type': 'application'
                        }
                    })
                    .then(this.handleResponse)
                    .catch(this.handleError);
            },
            handleResponse: function (response){
                this.response = new ConversionResponse(response.data.name, response.data.amountString);
            },
            handleError: function (error){
                if (error.response) {
                    console.log(error.response.data);
                    console.log(error.response.status);
                    console.log(error.response.headers);
                } else {
                    console.log('Error', error.message);
                }
                console.log(error.config);
            },
            clear: function () {
                this.response = {};
                this.errors = [];
            },
            validate: function () {
                if (!this.name) this.errors.push('Name required.');
                if (!this.amount) this.errors.push("Amount required. ");
                if (this.amount) {
                    if (typeof this.amount !== `number`
                        || this.amount < 0
                        || this.amount >= 1000000000000)
                        this.errors.push(`Amount must be a number between 0 (including) and 1,000,000,000,000 (excluding)`);
                }

                return this.errors.length === 0;
            }
        }
    }
</script>

<style>
    .main {
        width: 100%;
        min-height: 600px;
        display: flex;
        justify-content: flex-start;
        align-items: center;
        flex-direction: column;
    }

    #inputs {
        display: flex;
        flex-direction: column;
        padding-top: 20px;
        margin-top: 200px;
    }

    .buttons {
        display: flex;
        justify-content: space-between;
    }

    .display-box > span {
        display: block;
    }

    .heading {
        font-weight: bold;
        border-bottom: 2px solid #ddd;
        margin-bottom: 20px;
        font-size: 20px;
        padding-bottom: 3px;
    }

    .input-container {
        display: block;
        margin: 0 0 15px 0;
    }

    .input-container > span {
        width: 100px;
        font-weight: bold;
        float: left;
        padding-right: 5px;
    }

    .button {
        border: none;
        padding: 8px 15px 8px 15px;
        box-shadow: 1px 1px 4px #DADADA;
        border-radius: 3px;
        cursor: pointer;
    }

    .submit {
        background: #FF8500;
        color: #fff;
    }

    .submit:hover {
        background: orange;
    }

    .clear {
        background: bisque;
        color: #000;
    }

    .clear:hover {
        background: aquamarine;
    }

    .required {
        color: red;
    }

    input[type=number]::-webkit-inner-spin-button,
    input[type=number]::-webkit-outer-spin-button {
        -webkit-appearance: none;
        margin: 0;
    }
</style>
