<template>
    <div class="container">
      <div class="row text-center" style="display:block">YİYECEK OTOMAT WEB ARAYÜZ TASARIMI</div>
      <div class="row machine"  >
        <div class="col-md-8 ">

          
          <ul class="productlist">
            <li v-for="(item) in items" :key="item.message" @click="selectItem(item)" class="product">
               <div v-if="item.Select" class="selectItem">  
                   <div class="productName">{{item.name}} <br><b>{{item.price}}₺</b></div>    
                   <div class="itemNumber">{{item.id}}</div>
                </div>
                <div v-if="!item.Select"> 
                   <div class="productName">{{item.name}}<br> <b>{{item.price}}₺</b></div>     
                   <div class="itemNumber">{{item.id}}</div>
                </div>
              </li>
            </ul>
        </div>
        <div class="col-md-4 control-panel">
          <div class="Receipt" v-if="Receipt != null">
            <b-card bg-variant="light">
              <b-card-title><b>Ürün Bilgi Fişi</b></b-card-title>
              <b-card-title>Ürün Adı : {{Receipt.name}}</b-card-title>
              <b-card-title>Ürün Adeti : {{Receipt.quantitiy}}</b-card-title>
              <b-card-title>Ödeme Şekli : {{   GetPaymentTr( Receipt.payName)}}</b-card-title>
              <b-card-title v-if="Receipt.refund>0">Para Üstü : {{Receipt.refund}} ₺</b-card-title> 
           </b-card>
           Yeni bir ürün seçiniz..
          </div>
          <div  v-if="Receipt == null">

       
          <div class="col-md-12 selectProduct" >  
            {{selectedItem.id ?  selectedItem.name :'Ürün Seçiniz...'}}
          </div>
          <div v-if=" selectedItem.id != null" class="productCount">
              Ürün Adet
          <b-input-group>
          <b-input-group-prepend>
            <b-btn
               variant="danger"
              aria-pressed="true"
              @click="Quantity = Quantity > 1 ? Quantity - 1 : Quantity"
              >-</b-btn
            >
            </b-input-group-prepend>

            <b-form-input
              type="number"
              min="0"
              max="5"
              disabled
              v-model="Quantity"
            ></b-form-input>
          <b-input-group-append>
            <b-btn
              aria-pressed="false" 
              variant="success"
              @click="Quantity = Quantity < 5  ? Quantity + 1 : Quantity"
              >+</b-btn
            >
          </b-input-group-append>
        </b-input-group>
             </div>

            <div v-if=" selectedItem.productType != null && selectedItem.productType.drinkOption==1" class="sugarCount">
              Şeker Adet
          <b-input-group>
          <b-input-group-prepend>
            <b-btn
               variant="danger"
              aria-pressed="true"
              @click="SugarCount = SugarCount > 0 ? SugarCount - 1 : SugarCount"
              >-</b-btn
            >
            </b-input-group-prepend>

            <b-form-input
              type="number"
              min="0"
              max="5"
              disabled
              v-model="SugarCount"
            ></b-form-input>
          <b-input-group-append>
            <b-btn
              aria-pressed="false" 
              variant="success"
              @click="SugarCount = SugarCount < 5  ? SugarCount + 1 : SugarCount"
              >+</b-btn
            >
          </b-input-group-append>
        </b-input-group>
        
            </div>
          <div class="Total">
           Ödeme Tutarı : {{SumTotal}} ₺
            </div>
            <div   class="payment" v-if="selectedItem.id" >
            Ödeme Yöntemi
           <b-form-select 
           style=""
            @change="Money = 0"
            v-model="selectPayment" 
            :options="optionPayments"
          > 
          </b-form-select>
           
            <div v-if="selectPayment.id != 0">{{selectPayment.name}} İle Ödeme Yapabilirsiniz </div>
            <div v-if="selectPayment.id == 1">
             <!-- K.Kartı Ödeme -->
               <img src="@/assets/kredikartı.png" width="250px;" height="200px;" />
                <!-- Kredi Kartı ile ödeme yapabilirsimiz -->
            </div>
            <div v-if="selectPayment.id == 2">
             <!-- Temassız K.Kartı Ödeme -->
               <img src="@/assets/temassiz.png" width="250px;" height="200px;"/>
               <!-- Temassız Kredi Kartı İle Ödeme Yapabilirsiniz -->
            </div>
             <div v-if="selectPayment.id == 3">
             <!-- Bozuk Para Ödeme -->
             <img src="@/assets/coin.png" width="250px;" height="200px;"/>
             <!-- Bozuk Para İle Ödeme Yapabilirsiniz -->
                  <b-input-group>
                  <b-input-group-prepend>
                    <b-btn
                      variant="danger"
                      aria-pressed="true"
                      @click="Money = Money > 0 ? Money - 1 : Money"
                      >-</b-btn
                    >
                    </b-input-group-prepend>

                    <b-form-input
                      type="number" 
                      disabled
                      v-model="Money"
                    ></b-form-input>
                  <b-input-group-append>
                    <b-btn
                      aria-pressed="false" 
                      variant="success"
                      @click="Money = SumTotal > Money ? Money+1 : Money"
                      >+</b-btn
                    >
                  </b-input-group-append>
                  </b-input-group>        
            </div>
              <div v-if="selectPayment.id == 4">
                <!-- Nkkit Ödeme -->
             <img src="@/assets/banknot.png" width="250px;" height="200px;"/>

                <b-input-group>
                  <b-input-group-prepend>
                    <b-btn
                      variant="danger"
                      aria-pressed="true"
                      @click="Money = Money > 0 ? Money - 5 : Money"
                      >-</b-btn
                    >
                    </b-input-group-prepend>

                    <b-form-input
                      type="number"
                      min="0"
                      max="5"
                      disabled
                      v-model="Money"
                    ></b-form-input>
                  <b-input-group-append>
                    <b-btn
                      aria-pressed="false" 
                      variant="success"
                      @click="Money = SumTotal > Money ? Money+5 : Money"
                      >+</b-btn
                    >
                  </b-input-group-append>
              </b-input-group>        
                <!-- Nakit Banknont  -->
            </div> 
             </div>
            <div>   
              <b-button block variant="info" style="margin-top:10px"  :disabled="SumTotal > Money && (selectPayment.id == 4 || selectPayment.id == 3)"  @click="CompleteProduct"  v-if="selectedItem.id && selectPayment.id" >
              Ödemeyi Tamamla</b-button></div>
            <div>   <b-button block variant="danger" @click="CancelProduct" style="margin-top:10px" v-if="selectedItem.id" >Ürün İptal</b-button></div>

        </div>
      </div>
         </div>
    </div>
</template>

<script>
import axios from "../axios";

export default {
  name: 'OtomatVue',
  mounted : function(){ 
      this.getProducts();
      this.getPayments();
  } ,
  data(){
    return {
      items: [],
      selectedItem:{},
      selectPayment : {},
      optionPayments : [],
      SugarCount :0,
      Money:0,
      Quantity:1,
      SumTotal:0,
      Receipt:null
    }
  },
  watch:{
    Quantity(val){
        this.SumTotal = this.selectedItem.price * val;
    }
  },
  methods:{
      selectItem(item){  
        this.SugarCount = 0;
        this.Quantity = 1;
        this.items.map(val => val.Select = false);
        item.Select = true;
        this.selectedItem = item;
        this.SumTotal = item.price;
        this.Receipt = null;
      },
      getProducts(){
        axios
        .get(
          "products"
        ).then((res)=>{
          this.items=res.data.map((x)=>{
              x.Select = false;
              return x;
          }); 
        });
      },
      getPayments(){
        axios
        .get(
          "payments"
        ).then((res)=>{ 
            res.data.unshift({ id:0, name: "Ödeme Yöntemi Seçiniz",refund:false})
            this.optionPayments = res.data.map((res)=>{
              return {value : {id:res.id,refund:res.refund,name:res.name}, text: res.name};
            });
            this.selectPayment = {id:0,refund:false,name: "Ödeme Yöntemi Seçiniz"};
        });
      },
      CancelProduct(){
        this.makeToast('danger','Uyarı','Ürün İptal Edildi'); 
        this.ResetMachine();
      },
      CompleteProduct(){
        if(!this.MoneyControl(this.Money)){
          this.makeToast('danger','Uyarı','Nakit para giriniz!');
        }
        else if(this.SumTotal > this.Money && (this.selectPayment.id == 3 || this.selectPayment.id == 4)) {
          this.makeToast('danger','Uyarı','Yetersiz bakiye!');
        }else{
          this.makeToast('success','Uyarı','Sipariş Alındı Fişinizi Alınız...');
            let param =    {
                    "product": this.selectedItem,
                    "paymentOption": this.selectPayment.id,
                    "quantity": this.Quantity,
                    "money": this.Money   
              };                  
              axios.put("/payments/buy", param).then((res)=>{
                setTimeout(() => {
                  this.ResetMachine();
                  this.Receipt = res.data;
                }, 1000);
                setTimeout(() => {
                  this.Receipt = null;
                }, 8000);
              });   
        }
      },
      ResetMachine(){
        this.selectedItem = [];
        this.selectPayment = {};
        this.getProducts();
        this.getPayments();
        this.Money = 0;
        this.SugarCount = 0;
        this.Quantity = 1;
        this.SumTotal = 0;
      },
      SugarControl(value) {
        return value < 6 && value > 0 ? value : 0;
      }, 
      MoneyControl(value){  
        if(this.selectPayment.id == 4 && value % 5 == 0){
          return true;
        }else if(this.selectPayment.id != 4){
          return true;
        }else{
          return false;
        }
      },
      GetPaymentTr(payName){
          switch(payName) {
            case "WithContact": return "Kredi Kartı"
            case "WithOutContact": return "Temassız Kredi Kartı"
            case "WithCoin": return "Bozuk Para"
            case "WithBaknote": return "Nakit Ödeme"
            default: return "Tanımsız Ödeme" 
          }
      },
      makeToast(variant = null,head,content) { 
        this.$bvToast.toast(content, {
          title: head,
          variant: variant,
          solid: true
        })
      },
    }
  } 
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.product {
  cursor:pointer;
    float: left;
    width: 124px;
    height: 100px;
    display: block;
    background: rgb(255, 255, 255);
    border-radius: 5px; 
    border: solid 1px black;
    margin: 2px;
}
.machine{
  background: rgb(184, 195, 196);
  width:100%;
  height: 750px;
  padding:25px;
  border-radius: 25px;
  border: solid 1px black;
} 
.productlist{
  height:100%;
  border-radius: 15px;
  background: rgb(255, 255, 255);
  padding:10px 15px!important;
  border: solid 1px black;
}
.control-panel{
  border-radius: 5px;
  height: 100%;
  background: white;
  border: solid 1px black;
  padding:0px 10px 0px 10px;
}
.selectItem{
  background:#35b95ea1;width:100%;height:100%;color:white;
}
.itemNumber {
    width: 50px;
    height: 30px;
    border: solid 1px black;
    display: block;
    margin: 33% 0px 0px 28%;
    background: #00d0ff29;
    border-radius: 5px;
}
.productName{
  display: block;
  height: 20px;
  font-size: 14px;
}
.selectProduct{
  padding: 8px; 
    font-family: -webkit-body;
    font-size: 25px;
    min-height: 52px;
    border: dotted 1px black;
    margin-top:10px;
}
.sugarCount{ 
  margin-top: 5px;
  margin-bottom: 5px;
  border: dotted 1px black;
  color: black;

}
.productCount{
   margin-top: 5px;
  margin-bottom: 5px;
  border: dotted 1px black;
  color: black;
}
.Receipt > .card-body > .card-title{
  text-align: left!important;
}
.Total{
  min-height: 50px;
  font-size: 25px;
     margin-top: 5px;
  margin-bottom: 5px;
  border: dotted 1px black;

}
.payment{
    margin-top: 5px;
  margin-bottom: 5px;
  border: dotted 1px black;
  padding:0px!important;
  min-height:150px;
}

.btn-outline-primary.focus,
.btn-outline-primary:focus {
  box-shadow: none;
}
.btn.focus,
.btn:focus {
  outline: 0;
  box-shadow: none;
}

</style>
