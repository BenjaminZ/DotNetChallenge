<template>
    <div class="main">
        <h1 class="heading">.Net Challenge</h1>
        <div id="inputs">
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
                <input type="submit" class="button" value="submit">
            </div>
        </div>
        <div class="display-box">
            <span>{{name}}</span>
            <span>{{amount}}</span>
        </div>
    </div>
</template>

<script>
    export default {
        data: function () {
            return {
                name: 'Name',
                amount: 0,
            }
        }
    }
</script>

<style>

    #inputs {
        display: flex;
        flex-direction: column;
        padding-top: 20px;
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
        background: #FF8500;
        color: #fff;
        box-shadow: 1px 1px 4px #DADADA;
        border-radius: 3px;
        cursor: pointer;
    }

    .button:hover {
        background: orange;
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
