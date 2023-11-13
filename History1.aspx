<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="History1.aspx.vb" Inherits="History1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/jsrender.js" type="text/javascript"></script>
<script type="text/javascript" src="js/jquery.totemticker.js"></script>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?v=3&amp;language=th-TH&amp;sensor=false"></script>
<script type="text/javascript" src="js/infobox.js"></script>

<link href="css/reset.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="css/easydropdown.css"/>
<link href="css/jquery.mCustomScrollbar.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<div id="contents" >
<div class="details">
<div id="station-detail">
<ul id="sub-station">
<li class="active" data="station-history"><div class="txt">ความเป็นมา</div></li>
<li data="station-object"><div class="txt">วัตถุประสงค์ของโครงการ</div></li>
<li data="station-area"><div class="txt">ขอบเขตเชิงพื้นที่</div></li>
<li data="station-subject"><div class="txt">ขอบเขตเชิงวิชาการ</div></li></ul>
</div>
</div>
<div id="content-about">
<div id="station-history" class="data">
<div class="img-right">
<div><img src="images/flood1.jpg" /></div>
<div><img src="images/flood2.jpg" vspace="20"/></div>
</div>
<p>จากปัญหาอุทกภัยในปี 2554 ได้เกิดขึ้นเป็นบริเวณกว้างในพื้นที่หลายจังหวัดของประเทศไทย และส่งผลกระทบอย่างรุนแรงต่อประชาชนทั่วไป เกษตรกร ผู้ประกอบการอุสาหกรรม ภาคธุรกิจ ภาคบริการ และความเชื่อมั่นของนักลงทุนทั้งภายในประเทศและต่างประเทศ จึงมีความจำเป็นต้องจัดทำแผนการบริหารจัดการน้ำในระยะเร่งด่วน เพื่อลดผลกระทบจากอุทกภัยในอนาคตต่อประชาสังคมและภาคเศรษฐกิจน้อยที่สุด และสร้างความเชื่อมั่นให้ประชาชน เกษตรกร ภาคธุรกิจ และ นักลงทุนในนิคมอุตสาหกรรมที่ได้รับผลกระทบ ตลอดจนสร้างความมั่นคงของประเทศจากวิกฤตอุทกภัย ซึ่งคณะอนุกรรมการด้านการวางแผนและกำหนดมาตรการแก้ไขปัญหาระยะเร่งด่วนภายใต้คณะกรรมการยุทธศาสตร์เพื่อการวางระบบการบริหารจัดการทรัพยากรน้ำ (กยน.) เป็นกลไกหลักในการขับเคลื่อนเพื่อให้เกิดผลในเชิงปฏิบัติในระยะเร่งด่วนและระยะสั้น เพื่อจัดทำแนวทาง มาตรการและแผนปฏิบัติการเพื่อเตรียมความพร้อมในการป้องกัน และแก้ไขปัญหาอุทกภัยในปี ๒๕๕๕ ทั้งในด้านการชะลอน้ำ การระบายน้ำ การปรับปรุงพนังกั้นน้ำและระบบระบายน้ำในเมือง รวมทั้งจัดทำกรอบการลงทุนตามแผนปฏิบัติการระยะเร่งด่วน พิจารณาวางระบบข้อมูลเพื่อคาดการณ์ปริมาณน้ำ เสนอแนะการพัฒนาระบบข้อมูลน้ำของประเทศ รวมถึงการเสนอแนะการจัดระบบเตือนภัยและระบบศูนย์เครื่องมืออุปกรณ์ที่ใช้ในการป้องกันและแก้ไขปัญหาอุทกภัย</p>
<p>
ตามแผนแม่บทของคณะกรรมการยุทธศาสตร์เพื่อวางระบบบริหารจัดการทรัพยากรน้ำ (กยน.) นั้น ได้มีการ กำหนดแผนการบรรเทาอุทกภัยในระยะเร่งด่วนและยั่งยืน โดยในระยะเร่งด่วนมีแผนงานหลักที่สำคัญ คือ แผนงานกำหนดพื้นที่รับน้ำนองและมาตรการช่วยเหลือผู้ที่ได้รับผลกระทบจากการใช้พื้นที่เพื่อการรับน้ำ โดยมุ่งเน้นพื้นที่ในเขตเจ้าพระยาตอนบนและเจ้าพระยาตอนล่าง ตามแนวทางของแผนแม่บทฯดังกล่าว 
</p><p>กรมชลประทานจึงเห็นควรดำเนินการจัดทำระบบบริหารจัดการน้ำให้มีประสิทธิภาพ และเป็นระบบที่จัดทำขึ้นเพื่อเป็นการเตือนภัยล่วงหน้า สามารถบรรเทาความเสียหายที่อาจจะเกิดขึ้นกับชีวิตและทรัพย์สินของราษฎร อันเนื่องมาจากอุทกภัย  จึงจำเป็นจะต้องใช้เทคโนโลยีที่ทันสมัยสำหรับการวัดระดับน้ำและมีการทำงานเป็นระบบอัตโนมัติ ข้อมูลที่ได้มีความถูกต้อง แม่นยำมีความรวดเร็ว ทำให้การบริหารจัดการน้ำได้อย่างมีประสิทธิภาพ </p> 
</div>
<div id="station-object" class="data">
<div class="img-right">
<div><img src="images/choapaya1.jpg" width="306" /></div>
<div><img src="images/choapaya2.jpg" vspace="20"/></div>
</div>
<p>กรมชลประทานมีความประสงค์ที่จะดำเนินการงานระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาซึ่งในโครงการนี้แบ่งออกเป็นกลุ่มย่อยจำนวน 3 กลุ่ม ดังต่อไปนี้ 
<ol>
  <li>	พื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน จำนวน 71 สถานี ซึ่งอยู่ในเขตพื้นที่รับผิดชอบของสำนักชลประทานที่ 3</li>
  <li>พื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันออก จำนวน 36 สถานี ซึ่งอยู่ในเขตพื้นที่รับผิดชอบของสำนักชลประทานที่ 10  </li>
  <li>พื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันตก จำนวน 13 สถานี ซึ่งอยู่ในเขตพื้นที่รับผิดชอบของสำนักชลประทานที่ 12 </li>
</ol>
</p>
<p> 
เพื่อใช้ประกอบการวางแผนบรรเทาปัญหาอุทกภัย การแจ้งเตือนภัย และการเตรียมความพร้อมเพื่อรับสถานการณ์ ทั้งในฤดูฝนและในฤดูแล้งในบริเวณพื้นที่เป้าหมาย ทั้งยังสามารถประยุกต์ใช้เป็นเครื่องมือ (Tools) ช่วยประกอบการตัดสินใจเพื่อบริหารจัดการน้ำอย่างมีประสิทธิภาพเพิ่มมากยิ่งขึ้นและสามารถใช้สำหรับการติดตามและเฝ้าระวังสถานการณ์น้ำ โดยมีวัตถุประสงค์ของโครงการประกอบด้วย

<ol>
  <li>เพื่อนำระบบการสื่อสารทางไกล (Remote sensing) คือ ระบบโทรมาตรขนาดเล็ก มาใช้ในการอ่านระดับน้ำ ของระบบส่งน้ำของโครงการฯ โดยนำข้อมูลซึ่งเป็นแบบปัจจุบัน (Real time) มาบริหารจัดการน้ำให้ทันต่อสภาวการณ์ต่าง ๆ อย่างถูกต้องแม่นยำ </li>
<li>พัฒนาระบบฐานข้อมูล ที่ได้จากการตรวจวัดข้อมูล ด้านอุตุนิยมวิทยา ด้านอุทกวิทยา โดยการเชื่อมโยง ข้อมูลจากฐานข้อมูลของระบบโทรมาตรขนาดเล็กสำหรับวัดระดับน้ำและน้ำฝนอัตโนมัติ  รวมถึงระยะยกบานระบายต่างๆ ที่ดำเนินการติดตั้งในพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน เพื่อการนำเสนอข้อมูลสู่สาธารณชน (Public Information System) ในรูปแบบของการนำเสนอผ่านเครือข่าย Internet และช่องทางอื่นที่เหมาะสมสำหรับผู้เกี่ยวข้อง</li>
</ol>
</p>
</div>
<div id="station-area" class="data">
<div class="under-head"><span class="group">กลุ่มที่ 1 : </span>ขอบเขตเชิงพื้นที่งานระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน (ดังแสดงไว้ในรูปที่ 1 และตารางที่ 1)<div class="expand"><img src="images/collapse.png" align="absmiddle"/></div>
</div>
<div class="map-img"><div class="table">
<table>
<tr>
<td width="35" align="right">สำดับที่</td>
<td width="20" align="center">สชป.</td>
<td width="150" align="center">อาคารชลประทาน</td>
<td width="70" align="center">ประเภทอาคาร</td>
<td width="60" align="center">ตำบล</td>
<td width="60" align="center">อำเภอ</td>
<td width="60" align="center">จังหวัด</td>
</tr>
<tr>
<td align="right">1</td>
<td align="center">3</td>
<td>ไซฟอน PL.0 กม. 2+175</td>
<td>ไซฟอน</td>
<td>วงฆ้อง</td>
<td>พรหมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">2</td>
<td align="center">3</td>
<td>ไซฟอน PL.0 กม. 11+673</td>
<td>ไซฟอน</td>
<td>ดงประคำ</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">3</td>
<td align="center">3</td>
<td>ทรบ. PL.0 กม. 12+375</td>
<td>ทรบ.</td>
<td>หอกลอง</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">4</td>
<td align="center">3</td>
<td>ทรบ.PL.0 กม. 10+375</td>
<td>ทรบ.</td>
<td>ดงประคำ</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">5</td>
<td align="center">3</td>
<td>ทรบ. PL.0 กม. 16+206</td>
<td>ทรบ.</td>
<td>ทับยายเชียง</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">6</td>
<td align="center">3</td>
<td>ทรบ. PL.0 กม. 20+635</td>
<td>ทรบ.</td>
<td>ทับยายเชียง</td>
<td>วัดโบสถ์</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">7</td>
<td align="center">3</td>
<td>ทรบ. PL.0 กม. 19+450</td>
<td>ทรบ.</td>
<td>ท้อแท้</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">8</td>
<td align="center">3</td>
<td>ทรบ. PL.0 กม. 4+795</td>
<td>ทรบ.</td>
<td>ศรีภิรมย์</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">9</td>
<td align="center">3</td>
<td>ทรบ.PL.0 กม. 6+472</td>
<td>ทรบ.</td>
<td>วงฆ้อง</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr><tr>
<td align="right">10</td>
<td align="center">3</td>
<td>ทรบ.PL.0 กม. 23+053</td>
<td>ปตร.</td>
<td>วงฆ้อง</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">11</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.2-138L</td>
<td>ปตร.</td>
<td>หนองแขม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">12</td>
<td align="center">3</td>
<td>ทรบ. PL.0 กม. 8+489</td>
<td>ทรบ.</td>
<td>ดงประคำ</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr><tr>
<td align="right">13</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-10L</td>
<td>ทรบ.</td>
<td>ท่านางงาม</td>
<td>บางระกำ</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">14</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-21L</td>
<td>ทรบ.</td>
<td>มะตูม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">15</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-25L</td>
<td>ทรบ.</td>
<td>มะตูม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr><tr>
<td align="right">16</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-30L</td>
<td>ทรบ.</td>
<td>มะตูม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">17</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-49L</td>
<td>ทรบ.</td>
<td>พรหมพิราม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">18</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-56L</td>
<td>ทรบ.</td>
<td>หนองแขม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">19</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-59L</td>
<td>ทรบ.</td>
<td>หนองแขม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">20</td>
<td align="center">3</td>
<td>ทรบ.คลองกรับพวง</td>
<td>ทรบ.</td>
<td>วังอิทก</td>
<td>บางระกำ</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">21</td>
<td align="center">3</td>
<td>ทรบ.คลองโก</td>
<td>ทรบ.</td>
<td>วังอิทก</td>
<td>บางระกำ</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">22</td>
<td align="center">3</td>
<td>ทรบ.คลองงู</td>
<td>ทรบ.</td>
<td>บางระกำ</td>
<td>บางระกำ</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">23</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-4L</td>
<td>ปตร.</td>
<td>งิ้วงาม</td>
<td>เมืองพิษณุโลก</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">24</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-19L</td>
<td>ปตร.</td>
<td>ท่าโพธิ์</td>
<td>เมือง</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">25</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-41L</td>
<td>ปตร.</td>
<td>บ้านไร่</td>
<td>บางกระทุ่ม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">26</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.1-43L</td>
<td>ปตร.</td>
<td>หนองแขม</td>
<td>พรพมพิราม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">27</td>
<td align="center">3</td>
<td>ทรบ.คลองสินเธาว์ (น่าน-5)</td>
<td>ทรบ.</td>
<td>บางไผ่</td>
<td>บางมูลนาก</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">28</td>
<td align="center">3</td>
<td>ทรบ.คลองหอไกร (น่าน 6)</td>
<td>ทรบ.</td>
<td>หอไกร</td>
<td>บางมูลนาก</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">29</td>
<td align="center">3</td>
<td>ทรบ.ท่าล่อ (ยม-1)</td>
<td>ทรบ.</td>
<td>กำแพงดิน</td>
<td>สามง่าม</td>
<td>พิจิตร</td>
</tr><tr>
<td align="right">30</td>
<td align="center">3</td>
<td>ทรบ.คลองน้ำโจน (น่าน-3)</td>
<td>ทรบ.</td>
<td>งิ้วราย</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">31</td>
<td align="center">3</td>
<td>ทรบ.พังน้อย (ยม-7)</td>
<td>ทรบ.</td>
<td>ท่าเสา</td>
<td>โพทะเล</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">32</td>
<td align="center">3</td>
<td>ทรบ.พันจอ (ยม-2)</td>
<td>ทรบ.</td>
<td>กำแพงดิน</td>
<td>สามง่าม</td>
<td>พิจิตร</td>
</tr><tr>
<td align="right">33</td>
<td align="center">3</td>
<td>ทรบ.รังนก (ยม-4)</td>
<td>ทรบ.</td>
<td>รังนก</td>
<td>สามง่าม</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">34</td>
<td align="center">3</td>
<td>ทรบ.สายชนวน (ยม-5)</td>
<td>ทรบ.</td>
<td>ไผ่ท่าโพ</td>
<td>โพธิ์ประทับช้าง</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">35</td>
<td align="center">3</td>
<td>ทรบ.หนองงู (ยม-3)</td>
<td>ทรบ.</td>
<td>สามง่าม</td>
<td>สามง่าม</td>
<td>พิจิตร</td>
</tr><tr>
<td align="right">36</td>
<td align="center">3</td>
<td>ทรบ.ห้วยเกตุ (น่าน-4)</td>
<td>ทรบ.</td>
<td>งิ้วราย</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">37</td>
<td align="center">3</td>
<td>ทรบ.ห้วยปากขวาน (ยม-6)</td>
<td>ทรบ.</td>
<td>บางลาย</td>
<td>บึงนาราง</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">38</td>
<td align="center">3</td>
<td>ปตร.คลองคัน (น่าน-2)</td>
<td>ปตร.</td>
<td>หังดง</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">39</td>
<td align="center">3</td>
<td>ทรบ.คลองท่าหลวง (น่าน-1)</td>
<td>ปตร.</td>
<td>ในเมือง</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">40</td>
<td align="center">3</td>
<td>ปตร.คลองบางแก้ว</td>
<td>ปตร.</td>
<td>บางระกำ</td>
<td>บางระกำ</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">41</td>
<td align="center">3</td>
<td>ปตร.แคววังทอง</td>
<td>ปตร.</td>
<td>ไผ่ล้อม</td>
<td>บางกระทุ่ม</td>
<td>พิษณุโลก</td>
</tr>
<tr>
<td align="right">42</td>
<td align="center">3</td>
<td>ปตร. DR.8</td>
<td>ปตร.</td>
<td>เนินมะกอก</td>
<td>บางมูลนาก</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">43</td>
<td align="center">3</td>
<td>ปตร. DR.10 (นครสวรรค์)</td>
<td>ปตร.</td>
<td>ฆะมัง</td>
<td>ชุมแสง</td>
<td>นครสวรรค์</td>
</tr>
<tr>
<td align="right">44</td>
<td align="center">3</td>
<td>ปตร. DR.9-0R (นครสวรรค์)</td>
<td>ปตร.</td>
<td>ฆะมัง</td>
<td>ชุมแสง</td>
<td>นครสวรรค์</td>
</tr>
<tr>
<td align="right">45</td>
<td align="center">3</td>
<td>ปตร. DR.11 (นครสวรรค์)</td>
<td>อาคารรับน้ำเข้า</td>
<td>วังสำโรง</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">46</td>
<td align="center">3</td>
<td>ปตร.วังแตงโม (นครสวรรค์)</td>
<td>อาคารรับน้ำเข้า</td>
<td>ท่าบัว</td>
<td>โพทะเล</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">47</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.2-145L</td>
<td>อาคารบังคับน้ำ</td>
<td>ย่านยาว</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">48</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.42</td>
<td>อาคารบังคับน้ำ</td>
<td>คลองคะเชนทร์</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">49</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.44</td>
<td>อาคารบังคับน้ำ</td>
<td>เมืองเก่า</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">50</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.49</td>
<td>อาคารบังคับน้ำ</td>
<td>วังสำโรง</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">51</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.50</td>
<td>อาคารบังคับน้ำ</td>
<td>ไผ่ท่าโพ</td>
<td>โพธิ์ประทับช้าง</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">52</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.54</td>
<td>อาคารบังคับน้ำ</td>
<td>ทับหมัน</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">53</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.61</td>
<td>อาคารบังคับน้ำ</td>
<td>ท่าบัว</td>
<td>โพทะเล</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">54</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.2-134L</td>
<td>อาคารบังคับน้ำ</td>
<td>โพทะเล</td>
<td>โพทะเล</td>
<td>พิจิตร</td5
</tr>
<tr>
<td align="right">55</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.64</td>
<td>อาคารบังคับน้ำ</td>
<td>ย่านยาว</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">56</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.65</td>
<td>อาคารบังคับน้ำ</td>
<td>คลองคะเชนทร์</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">57</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.67</td>
<td>อาคารบังคับน้ำ</td>
<td>เมืองเก่า</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">58</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.69</td>
<td>อาคารบังคับน้ำ</td>
<td>ดงปาคำ</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">59</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองส่งน้ำ C.73</td>
<td>อาคารบังคับน้ำ</td>
<td>วังหว้า</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">60</td>
<td align="center">3</td>
<td>ปตร.ปากคลองระบายน้ำ  DR.13-10R</td>
<td>อาคารรับน้ำเข้า</td>
<td>ท่าบัว</td>
<td>โพทะเล</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">61</td>
<td align="center">3</td>
<td>ปตร.ปากคลองระบายน้ำ DR.13-27R</td>
<td>อาคารรับน้ำเข้า</td>
<td>วัดขวาง</td>
<td>โพทะเล</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">62</td>
<td align="center">3</td>
<td>ปตร.ปากคลองระบายน้ำ  DR.13-40R</td>
<td>อาคารรับน้ำเข้า</td>
<td>บางลาย</td>
<td>บึงนาราง</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">63</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองระบายน้ำ  DR.13-69R</td>
<td>อาคารรับน้ำเข้า</td>
<td>วังสำโรง</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">64</td>
<td align="center">3</td>
<td>ปตร.ปากคลองระบายน้ำ  DR.2-103L</td>
<td>อาคารรับน้ำเข้า</td>
<td>โรงช้าง</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">65</td>
<td align="center">3</td>
<td>ปตร.ปากคลองระบายน้ำ  DR.2-98L</td>
<td>อาคารรับน้ำเข้า</td>
<td>วังจิก</td>
<td>โพธิ์ประทับช้าง</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">66</td>
<td align="center">3</td>
<td>ปตร.ปากคลองระบายน้ำ  DR.3</td>
<td>อาคารรับน้ำเข้า</td>
<td>ปากทาง</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">67</td>
<td align="center">3</td>
<td>ทรบ.ปากคลองระบายน้ำ  DR.4</td>
<td>อาคารรับน้ำเข้า</td>
<td>ฆะมัง</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">68</td>
<td align="center">3</td>
<td>ปตร.ปากคลองระบายน้ำ  DR.6</td>
<td>อาคารรับน้ำเข้า</td>
<td>บางไผ่</td>
<td>บางมูลนาก</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">69</td>
<td align="center">3</td>
<td>ปตร.ปลายคลองระบายน้ำ  DR.6-47L</td>
<td>อาคารรับน้ำเข้า</td>
<td>คลองคูณ</td>
<td>ตะพานหิน</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">70</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.2-129L</td>
<td>อาคารอัดน้ำ</td>
<td>ย่านยาว</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
<tr>
<td align="right">71</td>
<td align="center">3</td>
<td>ทรบ.คลอง DR.2-125L</td>
<td>อาคารอัดน้ำ</td>
<td>ในเมือง</td>
<td>เมืองพิจิตร</td>
<td>พิจิตร</td>
</tr>
</table>
<div class="under-txt">ตารางที่ 1 แสดงรายละเอียดจุดที่จะดำเนินการติดตั้งสถานีสนามระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน </div>
</div><img src="images/map1.jpg" width="380" />
<div class="under-txt">รูปที่ 1 แสดงภาพจุดที่จะดำเนินการติดตั้งสถานีสนามระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนบน </div>
</div>
<div class="section " ></div>
<div class="under-head"><span class="group">กลุ่มที่ 2 : </span>ขอบเขตเชิงพื้นที่งานระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันออก (ดังแสดงไว้ในรูปที่ 2 และตารางที่ 2)<div class="expand"><img src="images/expand.png" align="absmiddle"/></div>

</div>
<div class="map-img">
<div class="table">
<table>
<tr>
<td width="35" align="right">สำดับที่</td>
<td width="20" align="center">สชป.</td>
<td width="150" align="center">อาคารชลประทาน</td>
<td width="70" align="center">ประเภทอาคาร</td>
<td width="60" align="center">ตำบล</td>
<td width="60" align="center">อำเภอ</td>
<td width="60" align="center">จังหวัด</td>
</tr>
<tr>
<td align="right">1</td>
<td align="center">10</td>
<td>ท่อลอดคลองส่งน้ำ 1 ข.ส.1</td>
<td>ทรบ.</td>
<td>โผงเผง</td>
<td>ปาโมก</td>
<td>อ่างทอง</td>
</tr>
<tr>
<td align="right">2</td>
<td align="center">10</td>
<td>ทรบ.คลองส่งน้ำ 1ซ. ส.1</td>
<td>ทรบ.</td>
<td>บางชะนี</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">3</td>
<td align="center">10</td>
<td>คลองระบายใหญ่ บางบาล 1</td>
<td>ทรบ.</td>
<td>หัวเวียง</td>
<td>เสนา</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">4</td>
<td align="center">10</td>
<td>คลองส่งน้ำ ส.3</td>
<td>ทรบ.</td>
<td>บ้านแพน</td>
<td>เสนา</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">5</td>
<td align="center">10</td>
<td>คลองส่งน้ำ ส. 4</td>
<td>ทรบ.</td>
<td>น้ำเต้า</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">6</td>
<td align="center">10</td>
<td>ท่อลอดคลองส่งน้ำ 1 ซ.ส.2</td>
<td>ไซฟอน</td>
<td>วัดตะกู</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">7</td>
<td align="center">10</td>
<td>คันกั้นคลองส่งน้ำ ส.3</td>
<td>ไซฟอน</td>
<td>ทางช้าง</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">8</td>
<td align="center">10</td>
<td>คันกั้นน้ำโรงสูบน้ำที่ 4</td>
<td>ไซฟอน</td>
<td>น้ำเต้า</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">9</td>
<td align="center">10</td>
<td>ทรบ.ปลายคลองระบายใหญ่ 1ข. บางบาล 1</td>
<td>ไซฟอน</td>
<td>สะพานไทย</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr><tr>
<td align="right">10</td>
<td align="center">10</td>
<td>ประตูบานระบายปตร.1</td>
<td>ปตร.</td>
<td>กบเจา</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">11</td>
<td align="center">10</td>
<td>โรงสูบน้ำที่ 1</td>
<td>โรงสูบน้ำ</td>
<td>โผงเผง</td>
<td>ปาโมก</td>
<td>อ่างทอง</td>
</tr>
<tr>
<td align="right">12</td>
<td align="center">10</td>
<td>โรงสูบน้ำที่ 2</td>
<td>โรงสูบน้ำ</td>
<td>ทางช้าง</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr><tr>
<td align="right">13</td>
<td align="center">10</td>
<td>โรงสูบน้ำที่ 3</td>
<td>โรงสูบน้ำ</td>
<td>บ้านแพน</td>
<td>เสนา</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">14</td>
<td align="center">10</td>
<td>โรงสูบน้ำที่ 4</td>
<td>โรงสูบน้ำ</td>
<td>น้ำเต้า</td>
<td>บางบาล</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">15</td>
<td align="center">10</td>
<td>Waste Way   กม. 94+375</td>
<td>Waste Way</td>
<td>ถนนใหญ่</td>
<td>เมือง</td>
<td>ลพบุรี</td>
</tr><tr>
<td align="right">16</td>
<td align="center">10</td>
<td>ไซฟอนตอยาง กม.120+000</td>
<td>ไซฟอน</td>
<td>หนองโดน</td>
<td>หนองโดน</td>
<td>สระบุรี</td>
</tr>
<tr>
<td align="right">17</td>
<td align="center">10</td>
<td>ไซฟอนท่าแค  กม. 92+626</td>
<td>ไซฟอน</td>
<td>ท่าแค</td>
<td>เมืองลพบุรี</td>
<td>ลพบุรี</td>
</tr>
<tr>
<td align="right">18</td>
<td align="center">10</td>
<td>ไซฟอนบ้านกลับ กม.108+792</td>
<td>ไซฟอน</td>
<td>บ้านกลับ</td>
<td>หนองโดน</td>
<td>สระบุรี</td>
</tr>
<tr>
<td align="right">19</td>
<td align="center">10</td>
<td>ไซฟอนหนองเลา กม. 82+500</td>
<td>ไซฟอน</td>
<td>หนองเต่า</td>
<td>บ้านหมี่</td>
<td>ลพบุรี</td>
</tr>
<tr>
<td align="right">20</td>
<td align="center">10</td>
<td>ทรบ.ปากคลอง  18 ขวา</td>
<td>ทรบ.</td>
<td>โคกกระเทียม</td>
<td>เมืองลพบุรี</td>
<td>ลพบุรี</td>
</tr>
<tr>
<td align="right">21</td>
<td align="center">10</td>
<td>ทรบ.ปากคลอง 21 ขวา</td>
<td>ทรบ.</td>
<td>ท่าหิน</td>
<td>เมืองลพบุรี</td>
<td>ลพบุรี</td>
</tr>
<tr>
<td align="right">22</td>
<td align="center">10</td>
<td>ปตร.คลองตาเมฆ</td>
<td>ปตร.</td>
<td>บ้านแพรก</td>
<td>บ้านแพรก</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">23</td>
<td align="center">10</td>
<td>ปตร.คลองน้อย</td>
<td>ปตร.</td>
<td>คลองน้อย</td>
<td>บ้านแพรก</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">24</td>
<td align="center">10</td>
<td>ปตร.บางกุ่ม</td>
<td>ปตร.</td>
<td>บ้านขล้อ</td>
<td>บางปะหัน</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">25</td>
<td align="center">10</td>
<td>ปตร.โพธิ์เก้าต้น</td>
<td>ปตร.</td>
<td>บางคู้</td>
<td>ท่าวุ้ง</td>
<td>ลพบุรี</td>
</tr>
<tr>
<td align="right">26</td>
<td align="center">10</td>
<td>ทรบ.บางโพธิ์</td>
<td>ทรบ.</td>
<td>ตลุก</td>
<td>สรรพยา</td>
<td>ชัยนาท</td>
</tr>
<tr>
<td align="right">27</td>
<td align="center">10</td>
<td>ปตร.มหาราช    (สถานีตัวอย่าง แบบ 1A)</td>
<td>ประตูระบายน้ำ</td>
<td>ตลุก</td>
<td>สรรพยา</td>
<td>ชัยนาท</td>
</tr>
<tr>
<td align="right">28</td>
<td align="center">10</td>
<td>ปตร.บางกุ้ง  กม. 25+480</td>
<td>ประตูระบายน้ำ</td>
<td>บ้านหม้อ</td>
<td>พรหมบุรี</td>
<td>สิงห์บุรี</td>
</tr>
<tr>
<td align="right">29</td>
<td align="center">10</td>
<td>ปตร.ปลายคลองบางแก้ว</td>
<td>ประตูระบายน้ำ</td>
<td>โพกรวม</td>
<td>เมืองสิงห์บุรี</td>
<td>สิงห์บุรี</td>
</tr><tr>
<td align="right">30</td>
<td align="center">10</td>
<td>ปตร.บางคู้</td>
<td>ประตูระบายน้ำ</td>
<td>พรหมมาสตร์</td>
<td>เมืองลพบุรี</td>
<td>ลพบุรี</td>
</tr>
<tr>
<td align="right">31</td>
<td align="center">10</td>
<td>ปตร.วัดมณีชลขันฑ์</td>
<td>ประตูระบายน้ำ</td>
<td>พรหมมาสตร์</td>
<td>เมืองลพบุรี</td>
<td>ลพบุรี</td>
</tr>
<tr>
<td align="right">32</td>
<td align="center">10</td>
<td>ปตร.วัดอุโลม</td>
<td>ประตูระบายน้ำ</td>
<td>มหาราช</td>
<td>มหาราช</td>
<td>อยุธยา</td>
</tr><tr>
<td align="right">33</td>
<td align="center">10</td>
<td>ปตร.วัดไลย์ (ปตร.ท่าโขลง)</td>
<td>ทรบ.</td>
<td>ตลุก</td>
<td>สรรพยา</td>
<td>ชัยนาท</td>
</tr>
<tr>
<td align="right">34</td>
<td align="center">10</td>
<td>ทุ่งเชียงราก  (สะพานคลองเชียงราก)</td>
<td>ปตร.</td>
<td>ชีน้ำร้าย</td>
<td>อินทร์บุรี</td>
<td>สิงห์บุรี</td>
</tr>
<tr>
<td align="right">35</td>
<td align="center">10</td>
<td>ปตร.ปากคลองบางพระครู</td>
<td>ปตร.</td>
<td>บางพระครู</td>
<td>นครหลวง</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">36</td>
<td align="center">10</td>
<td>ปตร.กระทุ่ม</td>
<td>ปตร.</td>
<td>กะทุ่ม</td>
<td>มหาราช</td>
<td>อยุธยา</td>
</tr>

</table>
<div class="under-txt">ตารางที่ 2 แสดงรายละเอียดจุดที่จะดำเนินการติดตั้งสถานีสนามระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันออก </div>
</div><img src="images/map2.jpg" width="380"  />
<div class="under-txt">รูปที่ 2 แสดงภาพจุดที่จะดำเนินการติดตั้งสถานีสนามระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันออก </div></div>
<div class="section "></div>
<div class="under-head" ><span class="group">กลุ่มที่ 3 : </span>ขอบเขตเชิงพื้นที่งานระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันตก (ดังแสดงไว้ในรูปที่ 3 และตารางที่ 3)<div class="expand"><img src="images/collapse.png" align="absmiddle"/></div></div>
<div class="map-img"><div class="table">
<table>
<tr>
<td width="35" align="right">สำดับที่</td>
<td width="20" align="center">สชป.</td>
<td width="150" align="center">อาคารชลประทาน</td>
<td width="70" align="center">ประเภทอาคาร</td>
<td width="60" align="center">ตำบล</td>
<td width="60" align="center">อำเภอ</td>
<td width="60" align="center">จังหวัด</td>
</tr>
<tr>
<td align="right">1</td>
<td align="center">12</td>
<td>ทรบ.ปากคลอง 1ข-1ข.ยางมณี</td>
<td>ทรบ.</td>
<td>องครักษ์</td>
<td>โพธิ์ทอง</td>
<td>อ่างทอง</td>
</tr>
<tr>
<td align="right">2</td>
<td align="center">12</td>
<td>ทรบ.ปากคลอง 1ซ.ยางมณี</td>
<td>ทรบ.</td>
<td>มหาดไทย</td>
<td>เมือง</td>
<td>อ่างทอง</td>
</tr>
<tr>
<td align="right">3</td>
<td align="center">12</td>
<td>ทรบ.ปากคลอง 1ซ.-1ซ.ยางมณี</td>
<td>ทรบ.</td>
<td>อินทรประมูล</td>
<td>โพธิ์ทอง</td>
<td>อ่างทอง</td>
</tr>
<tr>
<td align="right">4</td>
<td align="center">12</td>
<td>ทรบ.ปากคลอง 2ซ.ชัณสูตร</td>
<td>ทรบ.</td>
<td>ท่าข้าม</td>
<td>ค่ายบางระจัน</td>
<td>สิงห์บุรี</td>
</tr>
<tr>
<td align="right">5</td>
<td align="center">12</td>
<td>ปตร.คลองตาเที่ยง</td>
<td>ปตร.</td>
<td>ไผ่จำศีล</td>
<td>วิเศษชัยชาญ</td>
<td>อ่างทอง</td>
</tr>
<tr>
<td align="right">6</td>
<td align="center">12</td>
<td>ปตร.ท่าอู่</td>
<td>ปตร.</td>
<td>นรสิงค์</td>
<td>ป่าโมก</td>
<td>อ่างทอง</td>
</tr>
<tr>
<td align="right">7</td>
<td align="center">12</td>
<td>ปตร.บางบุ่ง</td>
<td>ปตร.</td>
<td>ประศุก</td>
<td>อินทร์บุรี</td>
<td>สิงห์บุรี</td>
</tr>
<tr>
<td align="right">8</td>
<td align="center">12</td>
<td>ปตร.บางสารวัตร</td>
<td>ปตร.</td>
<td>โพนางดำดก</td>
<td>สรรพยา</td>
<td>ชัยนาท</td>
</tr>
<tr>
<td align="right">9</td>
<td align="center">12</td>
<td>ปตร.บางเสวย</td>
<td>ปตร.</td>
<td>โพนางดำดก</td>
<td>สรรพยา</td>
<td>ชัยนาท</td>
</tr><tr>
<td align="right">10</td>
<td align="center">12</td>
<td>ปตร.ลาดใน</td>
<td>ปตร.</td>
<td>อมฤต</td>
<td>ผักไห่</td>
<td>อยุธยา</td>
</tr>
<tr>
<td align="right">11</td>
<td align="center">12</td>
<td>ปตร.ลำชวด</td>
<td>ปตร.</td>
<td>พระงาม</td>
<td>พรหมบุรี</td>
<td>สิงห์บุรี</td>
</tr>
<tr>
<td align="right">12</td>
<td align="center">12</td>
<td>ปตร.ศาลาแดง</td>
<td>ปตร.</td>
<td>บางแก้ง</td>
<td>เมือง</td>
<td>อ่างทอง</td>
</tr><tr>
<td align="right">13</td>
<td align="center">12</td>
<td>ร.สายใหญ่ ม.น้อย2</td>
<td>ปตร.</td>
<td>ห้วยชัน</td>
<td>อินทร์บุรี</td>
<td>สิงห์บุรี</td>
</tr>
</table>
<div class="under-txt">ตารางที่ 3 แสดงรายละเอียดจุดที่จะดำเนินการติดตั้งสถานีสนามระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันตก </div>
</div><img src="images/map3.jpg" width="380"  />
<div class="under-txt">รูปที่ 3 แสดงภาพจุดที่จะดำเนินการติดตั้งสถานีสนามระบบโทรมาตรขนาดเล็กสำหรับตรวจวัดพื้นที่รับน้ำนองในเขตพื้นที่ลุ่มน้ำเจ้าพระยาตอนล่างฝั่งตะวันตก </div>
</div>
<div class="section "></div>
</div>
<div id="station-subject" class="data">
<div class="img-right">
<div><img src="images/water_level1.jpg" width="306" /></div>
 
</div>
<p>วางระบบโครงข่ายการตรวจวัดและรับ-ส่งข้อมูลอุทกวิทยาทางไกลแบบอัตโนมัติ มีองค์ประกอบ ดังนี้
<ol><li>สถานีสนามที่จะดำเนินการจัดทำใหม่ โดยจำนวนสถานีสนามรวมทั้งสิ้น 120 สถานี (ประกอบด้วย สถานีวัดปริมาณน้ำฝน และ/หรือ ระดับน้ำท่า) </li>
<li>ทำการตรวจวัดข้อมูลปริมาณน้ำฝน และ/หรือ ระดับน้ำท่า  ระยะยกบานระบาย(บางสถานี) พร้อมกับส่งข้อมูลผ่านระบบเครือข่าย GPRS แสดงผลด้วยระบบอินเตอร์เน็ต เพื่อจัดเก็บข้อมูลลงในระบบฐานข้อมูลอย่างถูกต้องและต่อเนื่องสามารถนำมาประยุกต์เป็นข้อมูลเพื่อบริหารจัดการน้ำ</li>
</ol>

</p>
</div>
</div>
</div>
  <script type="text/javascript">
  var storeInfo = [

        <%
        Dim gate1,gate2,gate3,gate4,gate5,gate6,gate7 as String

  For row As Integer = 0 to Session("wStation").GetUpperBound(0)
   Dim code as String = CStr(Session("wStation")(row,0))
   Dim name as String = Session("wStation")(row,1)
   Dim lat as String = CStr(Session("wStation")(row,9))
   Dim lng as String = CStr(Session("wStation")(row,10))
   Dim group_name as String = CStr(Session("wStation")(row,2))
   Dim water as String = CStr(Session("wStation")(row,4))
   Dim wl_up as String = CStr(Session("wStation")(row,4))
   Dim wl_down as String = CStr(Session("wStation")(row,5))
   Dim zerogauge as String = CStr(Session("wStation")(row,16))
   Dim rf15 as String = CStr(Session("wStation")(row,6))
   Dim rf7tonow as String = CStr(Session("wStation")(row,8))
   Dim rf7to7 as String = CStr(Session("wStation")(row,7))
   Dim stnID as String = CStr(Session("wStation")(row,0))
   Dim address as String = CStr(Session("wStation")(row,14))
   Dim province_id as String = CStr(Session("wStation")(row,13))
   Dim province_name as String = CStr(Session("wStation")(row,14))
	Dim group as string = CStr(Session("wStation")(row,3))
    Dim typestn as string = CStr(Session("wStation")(row,15))
    Dim basin_id as string = CStr(Session("wStation")(row,11))
    Dim basin_name as String = CStr(Session("wStation")(row,12))
    Dim station_code as String = CStr(Session("wStation")(row,26))
    Dim gatecount as Integer = Session("wStation")(row,17)
    Dim LinkUrl as String = CStr(Session("wStation")(row,25))
    if (gatecount = 1) Then
    gate1 = CStr(Session("wStation")(row,18))
    elseif (gatecount = 2) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    elseif (gatecount = 3) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    elseif (gatecount = 4) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    elseif (gatecount = 5) Then
 gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    gate5 = CStr(Session("wStation")(row,22))
    elseif (gatecount = 6) Then
    gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    gate5 = CStr(Session("wStation")(row,22))
    gate6 = CStr(Session("wStation")(row,23))
    elseif (gatecount = 7) Then
   gate1 = CStr(Session("wStation")(row,18))
    gate2 = CStr(Session("wStation")(row,19))
    gate3 = CStr(Session("wStation")(row,20))
    gate4 = CStr(Session("wStation")(row,21))
    gate5 = CStr(Session("wStation")(row,22))
    gate6 = CStr(Session("wStation")(row,23))
    gate7 = CStr(Session("wStation")(row,24))
    end if
%>
  {    
                   code: "<% Response.Write(code) %>",
                   code_customer:"<% Response.Write(station_code) %>",
					name: "<% Response.Write(name) %>",
					 address: "<% Response.Write(name) %>",
					group: '<% Response.Write(group) %>',
					 group_name: "<% Response.Write(group_name) %>",
                     province_id:"<% Response.Write(province_id) %>",
                     province_name:"<% Response.Write(province_name) %>",
                     basin_id:"<% Response.Write(basin_id) %>",
                     basin_name:"<% Response.Write(basin_name) %>",
//					water: '<% Response.Write(water) %>',
                    water: '<% Response.Write(typestn) %>',
					rain: '<% Response.Write(rf15) %>',
                    rain7to7: '<% Response.Write(rf7to7) %>',
                    rain7tonow: '<% Response.Write(rf7tonow) %>',
					lat: '<% Response.Write(lat) %>',
                    long: '<% Response.Write(lng) %>',
                    gatecount: '<% Response.Write(gatecount) %>',
                    linkurl:"<% Response.Write(LinkUrl) %>",
	                water_level:
					{
					    value1: '<% Response.Write(wl_up) %>',
					    value2: '<% Response.Write(wl_down) %>',
					    value3: '<% Response.Write(zerogauge) %>'
					},
                    <% if gatecount = 1 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					}
                    ]
                    <% Elseif gatecount = 2 Then%>
                     door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}
                    ]
                    <% Elseif gatecount = 3 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}
                    ]
                    <% Elseif gatecount = 4 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}
					 ]
                    <% Elseif gatecount = 5 Then%>
                    door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}, {
					    value: '<% Response.Write(gate5) %>'
					}
					 ]
                     <% Elseif gatecount = 6 Then%>
                     door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}, {
					    value: '<% Response.Write(gate5) %>'
					}, {
					    value: '<% Response.Write(gate6) %>'
					}
					 ]
                     <% Elseif gatecount = 7 Then%>
                     door_level: [
					{
					    value: '<% Response.Write(gate1) %>'
					},
					{
					    value: '<% Response.Write(gate2) %>'
					}, {
					    value: '<% Response.Write(gate3) %>'
					}, {
					    value: '<% Response.Write(gate4) %>'
					}, {
					    value: '<% Response.Write(gate5) %>'
					}, {
					    value: '<% Response.Write(gate6) %>'
					}, {
					    value: '<% Response.Write(gate7) %>'
					}
					 ]
                       <% End If %>
  }<% If row < Session("wStation").GetUpperBound(0) Then Response.Write(",") %>
  <%
Next
%>
];

var basin_group = [

        <%
  For row As Integer = 0 to Session("basin").GetUpperBound(0)
   
   Dim name as String = CStr(Session("basin")(row,1))
%>
     
				"<% Response.Write(name) %>"
  <% If row < Session("basin").GetUpperBound(0) Then Response.Write(",") %>
  <%
Next
%>
];
var province_group = [

        <%
  For row As Integer = 0 to Session("province").GetUpperBound(0)
   
   Dim name as String = CStr(Session("province")(row,1))
%>
     
				"<% Response.Write(name) %>"
  <% If row < Session("province").GetUpperBound(0) Then Response.Write(",") %>
  <%
Next
%>
];

<%
    Dim nor_new as Integer = Session("Icon")(0,0)
    Dim nor_old as Integer = Session("Icon")(0,1)
    Dim warn_new as Integer = Session("Icon")(0,2)
    Dim warn_old as Integer = Session("Icon")(0,3)
    Dim cri_new as Integer = Session("Icon")(0,4)
    Dim cri_old as Integer = Session("Icon")(0,5)
%>
var icons1 = [
		{
		    icon: "pin-01.png",
		    icon2: "pin-11.png",
		    unit1: "<% Response.Write(nor_new) %>",
		    unit2: "<% Response.Write(nor_old) %>",
		    title: "ปกติ",
		    title_e: "Normal"
		},
		{
		    icon: "pin-02.png",
		    icon2: "pin-12.png",
		   unit1: "<% Response.Write(warn_new) %>",
		    unit2: "<% Response.Write(warn_old) %>",
		    title: "เตือนภัย",
		    title_e: "Warning"
		},
		{
		    icon: "pin-03.png",
		    icon2: "pin-13.png",
		  unit1: "<% Response.Write(cri_new) %>",
		    unit2: "<% Response.Write(cri_old) %>",
		    title: "วิกฤติ",
		    title_e: "Urgent"
		}

	];

      $(function () {

          $("#station-history").show();
          $("#station-object").hide();
          $("#station-area").hide();
          $("#station-subject").hide();
          $("#sub-station li").click(function () {
              $("#sub-station li").removeClass('active');
              $(this).addClass('active');
              $("div.data").hide();
              $("#" + $(this).attr('data')).fadeIn();

          });
      });	
 
 
</script>
<script src="js/config.js" type="text/javascript"></script>
<script src="js/menu.js" type="text/javascript"></script>
<script src="js/jquery.easydropdown.js"></script>
<script src="js/jquery.mCustomScrollbar.js"></script>	
<script type="text/javascript">
    

    $(document).ready(function (e) {
        $("#menu-3").addClass('active');
        
    });	



</script> 
</asp:Content>

